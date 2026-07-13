using Microsoft.EntityFrameworkCore;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Infrastructure.Persistence.Repositories;

public sealed class CoachRepository(ApplicationDbContext dbContext) : ICoachRepository
{
    public async Task<Coach?> GetCoachByIdAsync(CoachId id)
    {
        return await dbContext.Coaches
            .FindAsync(id);
    }

    public async Task<IReadOnlyList<Coach>> ListCoachesAsync()
    {
        return await dbContext.Coaches
            .ToListAsync();
    }

    public void AddCoach(Coach coach)
    {
        dbContext.Coaches
            .Add(coach);
    }

    public void RemoveCoach(Coach coach)
    {
        dbContext.Coaches
            .Remove(coach);
    }
}