using AutoMapper;
using AutoMapper.QueryableExtensions;
using MakeTopGreatAgain.Data;
using MakeTopGreatAgain.Database;
using MakeTopGreatAgain.Models.Users;
using MakeTopGreatAgain.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MakeTopGreatAgain.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController(
    IMapper mapper,
    ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ICollection<GroupData>>> Index()
    {
        return await context.Groups
            .Include(x => x.Sensei)
            .ProjectTo<GroupData>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    [HttpPut]
    // [Authorize(Roles = "admin")]
    public async Task<ActionResult> Create(GroupCreateRequest group)
    {
        User? user = null;

        if (group.TeacherId is not null)
        {
            user = await context.Users.FindAsync(group.TeacherId.ToString());

            if (user is null)
            {
                return NotFound();
            }
        }

        await context.Groups.AddAsync(new Group 
        {
            Name = group.Title,
            StartedAt = group.StartsAt ?? DateTime.Now,
            Sensei = user
        });

        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("example")]
    public async Task<ActionResult> Create(
        [Required] [MinLength(10)] string title,
        DateTime? startsAt = null)
    {
        await context.Groups.AddAsync(new Group
        {
            Name = title,
            StartedAt = startsAt ?? DateTime.Now,
        });

        await context.SaveChangesAsync();

        return Ok();
    }
}

public class GroupCreateRequest 
{
    [Required(ErrorMessage = "Необходимо указать название группы")]
    [MinLength(10, ErrorMessage = "Название группы должно содержать как минимум 10 символов")]
    public string Title { get; set; }

    public DateTime? StartsAt { get; set; }

    public Guid? TeacherId { get; set; }

    [GreaterThan(10)]
    public int? amount {  get; set; }
}
