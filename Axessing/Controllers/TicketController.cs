using AutoMapper;
using Axessing.Data;
using Axessing.Models.Resource.InputModels;
using Axessing.Models.Schema;
using Axessing.Services.TicketUnit.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Sockets;

namespace Axessing.Controllers;

public class TicketController : BaseApiController
{
    private readonly ITicketMaster master;
    private readonly IMapper mapper;
    public TicketController(ApplicationDbContext context, IMapper mapper, ITicketMaster master)
    {
        this.mapper = mapper;
        this.master = master;
    }

    [HttpGet]
    public async Task<ActionResult<List<Ticket>>> GetTickets(int workspaceid, bool? backlog)
    {
        var tickets = await master.GetTicketsAsync(workspaceid, backlog ?? false);
        return tickets != null ? tickets : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicketById(int id)
    {
        var ticket = await master.GetTicketByIdAsync(id);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpGet, Route("getStages")]
    public IActionResult GetStages()
    {
        return Ok(Enum.GetNames(typeof(Stage)).Cast<string>().ToList());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody]TicketInputModel ticket)
    {
        var mapped = mapper.Map<TicketInputModel, Ticket>(ticket);

        // Initial stage is always Open
        mapped.Stage = Stage.Open;

        master.CreateTicket(mapped);
        await master.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditTicket(int id, [FromBody, Bind("Title,Description,Stage")] Ticket ticket)
    {
        Ticket? current = master.GetTicketById(id);
        if (current == null)
        {
            return NotFound();
        }

        try
        {
            current = mapper.Map<Ticket>(ticket);
            master.UpdateTicket(id, current);
            await master.SaveChangesAsync();
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
        var ticket = master.GetTicketById(id);
        if (ticket == null)
        {
            return NotFound();
        }

        try
        {
            master.DeleteTicket(ticket.Id);
            await master.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return BadRequest(new DBConcurrencyException(ex.Message));
        }

        return Ok();
    }
}
