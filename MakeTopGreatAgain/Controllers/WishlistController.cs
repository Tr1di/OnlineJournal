using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Subjects;
using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MakeTopGreatAgain.Controllers;

[ApiController]
[Route("[controller]")]
public class WishlistController(
    ApplicationDbContext context,
    UserManager<User> userManager
    ) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ICollection<Subject>>> Index()
    {
        var user = await userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }
        
        await context.Entry(user)
            .Collection(e => e.Wishlist)
            .LoadAsync();
        
        return user.Wishlist!.ToList();
    }
    
    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> Put(Guid id)
    {
        var user = await userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }
        
        var subject = await context.Subjects.FindAsync(id);

        if (subject == null)
        {
            return NotFound();
        }
        
        await context.Entry(user)
            .Collection(e => e.Wishlist)
            .LoadAsync();
        
        user.Wishlist!.Add(subject);

        await context.SaveChangesAsync();

        return Ok();
    }
}