using Axessing.Models.Schema;
using Microsoft.EntityFrameworkCore;

namespace Axessing.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
        modelBuilder.Entity<Ticket>().HasOne(t => t.Workspace).WithMany(w => w.Tickets).HasForeignKey(t => t.WorkspaceId);

        modelBuilder.Entity<Workspace>().HasMany(w => w.Tickets).WithOne(t => t.Workspace);

        var workspace = new Workspace
        {
            Id = 1,
            Name = "Axessing - Monorepo",
            Description = "Lorem ipsum dolor sit amet.",
            LogoURL = "https://png.pngtree.com/png-vector/20221119/ourmid/pngtree-aa-letter-logos-png-image_6471608.png",
       };

        modelBuilder.Entity<Workspace>().HasData(new List<Workspace>()
        {
            workspace
        });

        /*modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket
            {
                WorkspaceId = 1,
                Id = 1,
                Title = "Create new dashboard",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Open
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 2,
                Title = "Change state of data models",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Doing
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 3,
                Title = "Type state error when accessing ticket",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 4,
                Title = "Git log error after update",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Backlog
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 5,
                Title = "Wishlist sharing problems",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Review
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 6,
                Title = "Telegram does not accept list of type x",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Impediment
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 7,
                Title = "Button color palette should be changed",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Backlog
            },
            new Ticket
            {
                WorkspaceId = 1,
                Id = 8,
                Title = "Account appears only when logged in",
                Description = "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Stage = Stage.Done
            },
        });*/

        base.OnModelCreating(modelBuilder);
    }
}
