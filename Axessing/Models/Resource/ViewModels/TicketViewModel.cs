using Axessing.Models.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Axessing.Models.Resource.ViewModels;

public class TicketViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime LastModifiedDate { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Stage Stage { get; set; }

    // Relationship
    public ICollection<Label> Labels { get; set; } = new List<Label>();
    public Workspace Workspace { get; set; } = new Workspace();
    public int WorkspaceId { get; set; }
}
