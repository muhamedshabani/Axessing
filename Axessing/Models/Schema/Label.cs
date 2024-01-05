using System.ComponentModel.DataAnnotations;

namespace Axessing.Models.Schema;

public class Label
{
    public Label() { }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HexValue { get; set; } = string.Empty;

    // Relationship
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
