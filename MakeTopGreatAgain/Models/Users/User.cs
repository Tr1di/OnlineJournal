using MakeTopGreatAgain.Models.Subjects;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using MakeTopGreatAgain.Models.Lessons;

namespace MakeTopGreatAgain.Models.Users;

public class User : IdentityUser
{
    [MaxLength(255)]
    public virtual string? Name { get; set; }

    [MaxLength(255)]
    public virtual string? Surname { get; set; }
    
    public virtual DateTime? BirthDate { get; init; }
    
    public virtual IList<Subject>? Wishlist { get; init; }
    
    public virtual IList<Group>? Groups { get; init; }
    public virtual IList<GroupUser>? GroupRoles { get; init; }
}