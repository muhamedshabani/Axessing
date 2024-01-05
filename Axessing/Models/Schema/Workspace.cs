using System.ComponentModel.DataAnnotations;

namespace Axessing.Models.Schema;

public class Workspace
{
    public Workspace() { }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LogoURL { get; set; } = string.Empty;

    // Relationship
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
