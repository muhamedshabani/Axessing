using Axessing.Models.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Axessing.Services.WorkspaceUnit.Interface;

public interface IWorkspaceMaster
{
    public Workspace GetWorkspaceById(int id);
}
