using Axessing.Models.Schema;

namespace Axessing.Services.TicketUnit.Interface;

public interface ITicketMaster
{
    public Ticket GetTicketById(int id);
    public Task<Ticket> GetTicketByIdAsync(int id);
    public Task<List<Ticket>> GetTickets(int workspaceId, bool backlog);
    public Task<List<Ticket>> GetTicketsAsync(int workspaceId, bool backlog);
    public void CreateTicket(Ticket ticket);
    public void CreateTicketAsync(Ticket ticket);
    public void UpdateTicket(int id, Ticket ticket);
    public void DeleteTicket(int id);
    public int SaveChanges();
    public Task<int> SaveChangesAsync();
}
