using Axessing.Models.Schema;
using Axessing.Services.WorkspaceUnit.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Axessing.Controllers;

public class WorkspaceController : BaseApiController
{
    private readonly IWorkspaceMaster master;
    public WorkspaceController(IWorkspaceMaster master)
    {
        this.master = master;
    }

    [HttpGet]
    public IActionResult GetWorkspaceById(int id)
    {
        return Ok(master.GetWorkspaceById(id));
    }

    /*[HttpPost]
    public IActionResult CreateWorkspace([FromBody] WorkspaceInputModel workspace)
    {
        
    }*/
}
