using AutoMapper;
using Axessing.Data;
using Axessing.Models.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Sockets;

namespace Axessing.Controllers;

public class TicketController : BaseApiController
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
    public TicketController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Ticket>>> GetTickets()
    {
        return await context.Tickets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicketById(int id)
    {
        return await context.Tickets.FindAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody, Bind("Title,Description")] Ticket ticket)
    {
        var mapped = mapper.Map<Ticket>(ticket);
        context.Tickets.Add(mapped);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditTicket(int id, [FromBody, Bind("Title,Description,Stage")] Ticket ticket)
    {
        Ticket? current = context.Tickets.Find(id);
        if (current == null)
        {
            return NotFound();
        }

        try
        {
            current = mapper.Map<Ticket>(ticket);
            context.Tickets.Update(current);
            await context.SaveChangesAsync();
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
        var ticket = context.Tickets.Find(id);
        if (ticket == null)
        {
            return NotFound();
        }

        try
        {
            //context.DeletedTickets.Add(ticket);
            context.Tickets.Remove(ticket);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return BadRequest(new DBConcurrencyException(ex.Message));
        }

        return Ok();
    }
}
