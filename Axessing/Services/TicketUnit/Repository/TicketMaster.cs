using AutoMapper;
using Axessing.Data;
using Axessing.Models.Schema;
using Axessing.Services.TicketUnit.Interface;
using Microsoft.EntityFrameworkCore;

namespace Axessing.Services.TicketUnit.Repository;

public class TicketMaster : ITicketMaster
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
    public TicketMaster(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    // GET
    public Ticket GetTicketById(int id)
    {
        var ticket = context.Tickets.Find(id);
        return ticket;
    }

    // GET Async
    public async Task<Ticket> GetTicketByIdAsync(int id)
    {
        var ticket = await context.Tickets.FindAsync(id);
        return ticket;
    }
    
    // GET All
    public Task<List<Ticket>> GetTickets(int workspaceId, bool backlog)
    {
        var tickets = context.Tickets.OrderByDescending(t => t.CreatedDate).Where(
            t => t.Id == workspaceId && backlog ? 
                nameof(t.Stage).ToLower() == "backlog" : nameof(t.Stage).ToLower() != "backlog")
            .ToListAsync();

        return tickets;
    }

    // GET All Async
    public async Task<List<Ticket>> GetTicketsAsync(int workspaceId, bool backlog)
    {
        // ternary can not be simplified
        var tickets =
            backlog ?
            await context.Tickets
                .OrderByDescending(t => t.CreatedDate)
                .Where(t => t.Stage == 0 && t.WorkspaceId == workspaceId)
                .ToListAsync() :
            await context.Tickets
                .OrderByDescending(t => t.CreatedDate)
                .Where(t => t.Stage != 0 && t.WorkspaceId == workspaceId)
                .ToListAsync();

        return tickets;
    }

    // CREATE
    public void CreateTicket(Ticket ticket)
    {
        context.Tickets.Add(ticket);
    }

    // CREATE Async
    public async void CreateTicketAsync(Ticket ticket)
    {
        await context.Tickets.AddAsync(ticket);
    }

    // UPDATE
    public void UpdateTicket(int id, Ticket ticket)
    {
        var current = context.Tickets.Find(id);
        mapper.Map<Ticket, Ticket>(ticket, current);
        context.Update(ticket);
    }

    // DELETE
    public void DeleteTicket(int id)
    {
        var ticket = context.Tickets.Find(id);
        context.Tickets.Remove(ticket);
    }

    // SAVE
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    // SAVE Async
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
