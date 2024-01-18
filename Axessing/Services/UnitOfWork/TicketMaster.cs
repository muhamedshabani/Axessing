using AutoMapper;
using Axessing.Data;
using Axessing.Models.Resource;
using Axessing.Models.Schema;
using Microsoft.EntityFrameworkCore;

namespace Axessing.Services.UnitOfWork;

public class TicketMaster : IHelper<Ticket>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
    public TicketMaster(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public Ticket Get(int id)
    {
        var ticket = context.Tickets.Find(id);
        return ticket;
    }


    // GET All
    public List<Ticket> GetAll(RequestParams requestParams)
    {
        var tickets = context.Tickets.OrderByDescending(t => t.CreatedDate).ToList();
        if (requestParams.WorkspaceId != null)
        {
            tickets = tickets.Where(t => t.WorkspaceId == requestParams.WorkspaceId).ToList();
            // could be simplified?
            if (requestParams.Backlog == true)
            {
                tickets = tickets.Where(t => t.Stage == 0).ToList();
            }
            else
            {
                tickets = tickets.Where(t => t.Stage != 0).ToList();
            }
        }

        // TODO: implement page size, page count and take size

        /*        
        var tickets = context.Tickets.OrderByDescending(t => t.CreatedDate).Where(
        t => t.Id == workspaceId && backlog ?
            nameof(t.Stage).ToLower() == "backlog" : nameof(t.Stage).ToLower() != "backlog")
        .ToList();
        */

        return tickets;
    }

    // TODO: Remove old methods
    /*public List<Ticket> GetTickets(int workspaceId, bool backlog)
    {
        var tickets = context.Tickets.OrderByDescending(t => t.CreatedDate).Where(
            t => t.Id == workspaceId && backlog ? 
                nameof(t.Stage).ToLower() == "backlog" : nameof(t.Stage).ToLower() != "backlog")
            .ToList();

        return tickets;
    }*/

    // CREATE
    public void Create(Ticket ticket)
    {
        context.Tickets.Add(ticket);
    }

    // UPDATE
    public void Update(int id, Ticket ticket)
    {
        var current = context.Tickets.Find(id);
        mapper.Map<Ticket, Ticket>(ticket, current);
        context.Update(ticket);
    }

    // DELETE
    public void Delete(int id)
    {
        var ticket = context.Tickets.Find(id);
        if (ticket != null)
        {
            context.Tickets.Remove(ticket);
            // TODO: cascade delete attachments if any
        }
    }

    // SAVE
    public int Save()
    {
        return context.SaveChanges();
    }

    // SAVE Async
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
