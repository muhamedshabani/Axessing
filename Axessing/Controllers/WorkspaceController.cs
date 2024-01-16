using AutoMapper;
using Axessing.Models.Resource.InputModels;
using Axessing.Models.Schema;
using Axessing.Services.WorkspaceUnit.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Axessing.Controllers;

public class WorkspaceController : BaseApiController
{
    private readonly IWorkspaceMaster master;
    private readonly IMapper mapper;
    public WorkspaceController(IWorkspaceMaster master, IMapper mapper)
    {
        this.master = master;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetWorkspaceById(int id)
    {
        return Ok(master.GetWorkspaceById(id));
    }

    [HttpPost]
    public IActionResult CreateWorkspace([FromBody]WorkspaceInputModel workspace)
    {
        var mapped = mapper.Map<Workspace>(workspace);
        try
        {
            master.CreateWorkspace(mapped);
            master.SaveChangesAsync();
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status409Conflict);
        }

        return Ok();
    }
}
