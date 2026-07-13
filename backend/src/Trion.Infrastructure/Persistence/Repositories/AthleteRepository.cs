using Microsoft.EntityFrameworkCore;
using Trion.Domain.AthleteAggregate;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Infrastructure.Persistence.Repositories;

public sealed class AthleteRepository(ApplicationDbContext dbContext) : IAthleteRepository
{
    public async Task<IReadOnlyList<Athlete>> ListAsync()
    {
        return await dbContext.Athletes
            .ToListAsync();
    }

    public async Task<Athlete?> GetByIdAsync(AthleteId id)
    {
        return await dbContext.Athletes
            .FindAsync(id);
    }

    public void Add(Athlete athlete)
    {
        dbContext.Athletes
            .Add(athlete);
    }

    public void Remove(Athlete athlete)
    {
        dbContext.Athletes
            .Remove(athlete);
    }
}