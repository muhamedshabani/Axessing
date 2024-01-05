using Axessing.Models.Schema;
using Microsoft.EntityFrameworkCore;

namespace Axessing.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Ticket> Tickets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
        base.OnModelCreating(modelBuilder);
    }
}
