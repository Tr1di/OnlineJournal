using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;

namespace Web.Pages;

public class UsersModel(
    ApplicationDbContext context) : PageModel
{
    public IList<User>? Users { get; set; }
    
    public void OnGet()
    {
        Users = context.Users.ToList();
    }
}