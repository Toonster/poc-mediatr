using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class MediatrPocDbContext : DbContext
{
    public MediatrPocDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}