using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MakeTopGreatAgain.Models.Users;

[PrimaryKey(nameof(UserId),  nameof(GroupId))]
public class GroupUser
{
    public virtual string UserId { get; protected set; }
    public virtual Guid GroupId { get; protected set; }
    public virtual string RoleId { get; protected set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual required  User User { get; set; }
    
    [ForeignKey(nameof(GroupId))]
    public virtual required Group Group { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public virtual required IdentityRole Role { get; set; }
}