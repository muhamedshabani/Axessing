using AutoMapper;
using Axessing.Models.Resource.InputModels;
using Axessing.Models.Schema;
using Axessing.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Axessing.Controllers;

public class WorkspaceController : BaseApiController
{
    private readonly IHelper<Workspace> master;
    private readonly IMapper mapper;
    public WorkspaceController(IHelper<Workspace> master, IMapper mapper)
    {
        this.master = master;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetWorkspaceById(int id)
    {
        return Ok(master.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkspace([FromBody]WorkspaceInputModel workspace)
    {
        var mapped = mapper.Map<Workspace>(workspace);
        try
        {
            master.Create(mapped);
            await master.SaveAsync();
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status409Conflict);
        }

        return Ok();
    }
}
