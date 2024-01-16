using System;
using Axessing.Models.Schema;

namespace Axessing.Models.Resource.InputModels;

public class WorkspaceInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoURL { get; set; }

    ICollection<AppUser>? Collaborators { get; set; }
}

