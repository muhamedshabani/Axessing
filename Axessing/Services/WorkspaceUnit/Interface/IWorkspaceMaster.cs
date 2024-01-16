using Axessing.Models.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Axessing.Services.WorkspaceUnit.Interface;

public interface IWorkspaceMaster
{
    public Workspace GetWorkspaceById(int id);
    public void CreateWorkspace(Workspace workspace);
    public void CreateWorkspaceAsync(Workspace workspace);
    public int SaveChanges();
    public Task<int> SaveChangesAsync();
}
