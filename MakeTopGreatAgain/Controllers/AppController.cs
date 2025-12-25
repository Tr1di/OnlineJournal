using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Subjects;
using Microsoft.AspNetCore.Mvc;

namespace MakeTopGreatAgain.Controllers;

// Посчитать количество букв в слове

[ApiController]
[Route("[controller]")]
public class AppController(
    ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public ICollection<Subject> Get()
    {
        return context.Subjects.ToList();
    }
}
