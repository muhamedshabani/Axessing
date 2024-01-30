using Axessing.Models.Schema;

namespace Axessing.Models.Resource.ViewModels;

public class WorkspaceViewModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<AppUserViewModel>? Collaborators { get; set; }
}
