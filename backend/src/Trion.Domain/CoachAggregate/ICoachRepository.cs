using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Domain.CoachAggregate;

public interface ICoachRepository
{
    Task<Coach?> GetCoachByIdAsync(CoachId id);
    
    Task<IReadOnlyList<Coach>> ListCoachesAsync();
    
    void AddCoach(Coach coach);
    
    void RemoveCoach(Coach coach);
}