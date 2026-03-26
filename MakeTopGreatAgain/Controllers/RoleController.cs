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
public class RoleController(
    ApplicationDbContext context,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : ControllerBase
{
    // - Список всех ролей
    // - Создать роль
    // - Назначить роль пользователю
    // - Удалить роль
    //   * Если указан пользователь, то удалить роль только у него
    // - Посмотреть роли авторизованного пользователя
    //   (с точки зрения пользователя функционал по типу "мои роли")

    //public async Task Example()
    //{
    //    //// Список ролей получаем через context
    //    //// Создать роль
    //    //await roleManager.CreateAsync(new IdentityRole("admin"));
    //    //// Назначить роль
    //    //await userManager.AddToRoleAsync(user, "admin");
    //    //// Список ролей пользователя
    //    //await userManager.GetRolesAsync(user);
    //    //// Забрать роль у пользователя
    //    //await userManager.RemoveFromRoleAsync(user, "admin");
    //    //await roleManager.FindByNameAsync();
    //    //await roleManager.DeleteAsync();
    //}

    [HttpGet]
    [Authorize(Roles = "admin")] // Для авторизации необходимо иметь роль admin
    public async Task ExampleAuth() { }
}

