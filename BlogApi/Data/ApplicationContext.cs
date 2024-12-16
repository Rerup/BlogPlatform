using Domain.BlogDomain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public class ApplicationContext : DbContext
{

    public DbSet<Blog> Blog { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalBlogPlatform.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasData(
            new Blog { Id = 1, Title = "Blog 1", Content = "Some text" },
            new Blog { Id = 2, Title = "Blog 2", Content = "Some text" },
            new Blog { Id = 3, Title = "Blog 3", Content = "Some text" }
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment { Id = 1, Content = "Comment 1", BlogId = 1 },
            new Comment { Id = 2, Content = "Comment 2", BlogId = 1 },
            new Comment { Id = 3, Content = "Comment 3", BlogId = 2 }
        );

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker
            .Entries()
            .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified)
            .Select(i => i.Entity)
            .OfType<Auditable>();

        foreach (var e in entities)
        {
            e.Audit();
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
