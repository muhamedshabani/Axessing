using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Axessing.Models.Schema;

public class Ticket
{
    public Ticket() { }

    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime LastModifiedDate { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Stage Stage { get; set; }

    // Relationship
    public ICollection<Label> Labels { get; set; } = new List<Label>();
    [ForeignKey("WorkspaceId")]
    public Workspace Workspace { get; set; } = new Workspace();
    public int WorkspaceId { get; set; }
}
