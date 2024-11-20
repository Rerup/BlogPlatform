using System;
using Domain.BlogDomain;
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
}
