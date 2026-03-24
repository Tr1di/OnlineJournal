using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MakeTopGreatAgain.Models.Users;

[PrimaryKey(nameof(UserId), nameof(GroupId))]
[Index(nameof(UserId), nameof(IsSensei), IsUnique = true)]
public class GroupUser
{
    public virtual string UserId { get; protected init; }
    public virtual Guid GroupId { get; protected init; }
    
    [ForeignKey(nameof(UserId))]
    public virtual required User User { get; init; }
    
    [ForeignKey(nameof(GroupId))]
    public virtual required Group Group { get; init; }
    
    public virtual required bool IsSensei { get; init; }
}