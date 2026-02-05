using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MakeTopGreatAgain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(
        UserManager<User> userManger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var user = await userManger.GetUserAsync(User);
            return user!;
        }
    }
}
