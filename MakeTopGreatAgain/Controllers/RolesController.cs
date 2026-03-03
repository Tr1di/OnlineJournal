using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeTopGreatAgain.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController(
    ApplicationDbContext context,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "test")]
    public async Task<ActionResult<ICollection<IdentityRole>>> All()
    {
        return await context.Roles.ToListAsync();
    }

    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<IdentityRole>> Create(string name)
    {
        if (context.Roles.Any(role => role.Name == name))
        {
            return BadRequest();
        }
        
        var role = new IdentityRole(name);
        await roleManager.CreateAsync(role);
        return role;
    }
    
    [HttpPost]
    public async Task<ActionResult> Assign(Guid userId, string role)
    {
        var user = await context.Users.FindAsync(userId.ToString());

        if (user is null) return NotFound();
        
        await userManager.AddToRoleAsync(user, role);
        await userManager.UpdateSecurityStampAsync(user);
        
        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete(string role, Guid? userId)
    {
        if (userId is not null)
        {
            var user = await context.Users.FindAsync(userId.ToString());
            if (user is null) return NotFound();
            await userManager.RemoveFromRoleAsync(user, role);
        }
        else
        {
            var identity = await roleManager.FindByNameAsync(role);
            if (identity is null) return NotFound();
            await roleManager.DeleteAsync(identity);
        }

        return Ok();
    }
    
    [HttpGet("my")]
    [Authorize]
    public async Task<ActionResult<ICollection<string>>> My()
    {
        var user = await userManager.GetUserAsync(User);
        var roles = await userManager.GetRolesAsync(user!);
        return roles.ToList();
    }
}