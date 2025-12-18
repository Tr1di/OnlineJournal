using Microsoft.AspNetCore.Mvc;

namespace MakeTopGreatAgain.Controllers;

// Посчитать количество букв в слове

[ApiController]
[Route("[controller]")]
public class AppController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
    
    [HttpGet("length/{word}")]
    public string Info(string word)
    {
        return $"Hello, {word}!";
    }

    [HttpGet("length")]
    public string Info2(string word)
    {
        return $"Hello, {word}!";
    }
}
