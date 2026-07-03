using Microsoft.EntityFrameworkCore;
using Trion.Domain.CoachAggregate;

namespace Trion.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Coach> Coaches { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}