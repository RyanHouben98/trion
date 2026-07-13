using Microsoft.EntityFrameworkCore;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;
using Trion.Domain.CoachAggregate;

namespace Trion.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Coach> Coaches { get; set; }
    
    public DbSet<Athlete> Athletes { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}