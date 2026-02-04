using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models;
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
    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> Put(Guid id)
    {
        return Ok();
    }
}