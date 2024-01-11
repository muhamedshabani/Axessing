using Axessing.Data;
using Axessing.Models.Schema;
using Axessing.Services.WorkspaceUnit.Interface;

namespace Axessing.Services.WorkspaceUnit.Repository;

public class WorkspaceMaster : IWorkspaceMaster
{
    private readonly ApplicationDbContext context;
    public WorkspaceMaster(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Workspace GetWorkspaceById(int id)
    {
        var workspace = context.Workspaces.Find(id);
        return workspace;
    }
}
