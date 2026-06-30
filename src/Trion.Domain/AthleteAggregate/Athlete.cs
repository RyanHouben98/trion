using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Domain.AthleteAggregate;

public sealed class Athlete
{
    public AthleteId Id { get; }
    
    public string Name { get; }

    private Athlete(AthleteId athleteId, string name)
    {
        Id = athleteId;
        Name = name;
    }

    public static Athlete Create(string name)
    {
        return new Athlete(AthleteId.New(), name);
    }
}