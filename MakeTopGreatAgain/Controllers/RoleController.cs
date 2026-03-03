using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeTopGreatAgain.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController(
    ApplicationDbContext context,
    UserManager<User>  userManager,
    RoleManager<IdentityRole> roleManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ICollection<IdentityRole>>> All()
    {
        return await context.Roles.ToListAsync();
    }

    [HttpPut]
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
        var user = await context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound();
        }
        
        userManager.AddToRoleAsync(user, role).Wait();
        
        return Ok();
    }
}