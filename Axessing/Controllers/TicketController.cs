using AutoMapper;
using Axessing.Data;
using Axessing.Models.Resource;
using Axessing.Models.Resource.InputModels;
using Axessing.Models.Resource.ViewModels;
using Axessing.Models.Schema;
using Axessing.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Net.Sockets;

namespace Axessing.Controllers;

public class TicketController : BaseApiController
{
    private readonly IHelper<Ticket> master;
    private readonly IMapper mapper;
    public TicketController(ApplicationDbContext context, IMapper mapper, IHelper<Ticket> master)
    {
        this.mapper = mapper;
        this.master = master;
    }

    [HttpGet]
    public ActionResult<List<Ticket>> GetTickets(int workspaceid, bool? backlog)
    {
        var tickets = master.GetAll(new RequestParams { WorkspaceId = workspaceid, Backlog = backlog ?? false });
        var mapped = mapper.Map<List<TicketViewModel>>(tickets);
        return tickets != null ? Ok(mapped) : NotFound();
    }

    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicketById(int id)
    {
        var ticket = master.Get(id);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody]TicketInputModel ticket)
    {
        var mapped = mapper.Map<TicketInputModel, Ticket>(ticket);

        // Initial stage is always Open
        mapped.Stage = Stage.Open;

        master.Create(mapped);
        await master.SaveAsync();
        return Ok();
    } 

    [HttpPut]
    public async Task<IActionResult> EditTicket(int id, [FromBody, Bind("Title,Description,Stage")] Ticket ticket)
    {
        Ticket? current = master.Get(id);
        if (current == null)
        {
            return NotFound();
        }

        try
        {
            current = mapper.Map<Ticket>(ticket);
            master.Update(id, current);
            await master.SaveAsync();
        }
        catch (Exception ex)
        {
            return Ok(new DBConcurrencyException(ex.Message));
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var ticket = master.Get(id);
        if (ticket == null)
        {
            return NotFound();
        }

        try
        {
            master.Delete(ticket.Id);
            await master.SaveAsync();
        } 
        catch (Exception ex)
        {
            return BadRequest(new DBConcurrencyException(ex.Message));
        }

        return Ok();
    }

    [HttpGet, Route("getStages")]
    public IActionResult GetStages()
    {
        return Ok(Enum.GetNames(typeof(Stage)).Cast<string>().ToList());
    }
}
