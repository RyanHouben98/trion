using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Domain.AthleteAggregate;

public interface IAthleteRepository
{
    Task<IReadOnlyList<Athlete>> ListAsync();

    Task<Athlete?> GetByIdAsync(AthleteId id);
    
    void Add(Athlete athlete);
    
    void Remove(Athlete athlete);
}