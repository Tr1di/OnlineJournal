using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeTopGreatAgain.Models.Users;

public class Group
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid Id { get; protected init; }
    
    [MaxLength(255)]
    public virtual required string Name { get; init; }
    
    public virtual required DateTime StartedAt { get; init; }

    public virtual IList<User>? Users { get; init; }
    public virtual IList<GroupUser>? UserRoles { get; init; }
}