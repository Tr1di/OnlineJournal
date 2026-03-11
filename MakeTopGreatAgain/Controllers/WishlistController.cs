using System.Net;
using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Middleware.Restrict;
using MakeTopGreatAgain.Models;
using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MakeTopGreatAgain.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WishlistController(
    ApplicationDbContext context,
    UserManager<User> userManager
    ) : ControllerBase
{
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id)
    {
        return Ok();
    }
}