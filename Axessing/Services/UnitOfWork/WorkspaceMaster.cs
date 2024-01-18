using Axessing.Data;
using Axessing.Models.Resource;
using Axessing.Models.Schema;

namespace Axessing.Services.UnitOfWork;

public class WorkspaceMaster : IHelper<Workspace>
{
    private readonly ApplicationDbContext context;
    public WorkspaceMaster(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Workspace Get(int id)
    {
        var workspace = context.Workspaces.Find(id);
        return workspace;
    }

    public List<Workspace> GetAll(RequestParams requestParams)
    {
        var workspaces = context.Workspaces.ToList();
        if(requestParams.Take != null)
        {
            workspaces = workspaces.Take((int)requestParams.Take).ToList();
        }

        return workspaces;
    }

    public void Create(Workspace workspace)
    {
        context.Workspaces.Add(workspace);
    }

    public void Update(int id, Workspace entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        var entity = context.Workspaces.Find(id);
        if(entity != null)
        {
            context.Workspaces.Remove(entity);
        }
    }

    public int Save()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
