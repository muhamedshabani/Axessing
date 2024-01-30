using Axessing.Models.Schema;
using System.Text.Json.Serialization;

namespace Axessing.Models.Resource.InputModels;

public class TicketInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Stage Stage { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    public int WorkspaceId { get; set; }
}
