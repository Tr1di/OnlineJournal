using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeTopGreatAgain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(
        UserManager<User> userManger,
        ApplicationDbContext context) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<ICollection<User>>> Index()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<User>> Get()
        {
            var user = await userManger.GetUserAsync(User);
            return user!;
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult> Update(UpdateUserData userData)
        {
            var user = await userManger.GetUserAsync(User);

            user.Name = userData.Name;
            user.Surname = userData.LastName;

            await context.SaveChangesAsync();

            return Ok();
        }
    }

    public class UpdateUserData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class CreateGroupData
    {
        public string Title { get; set; }
        public Guid? TeacherId { get; set; }
    }
}
