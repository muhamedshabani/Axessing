using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axessing.Models.Schema;

public class AppUser : IdentityUser
{

    public string Name { get; set; }

    // Relationship

    public int WorkspaceId { get; set; }
    [ForeignKey(nameof(WorkspaceId))]
    public Workspace Workspace { get; set; }
    //public ICollection<Ticket> Tickets { get; set; }

}
