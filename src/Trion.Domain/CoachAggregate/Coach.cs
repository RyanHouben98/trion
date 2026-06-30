using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Domain.CoachAggregate;

public sealed class Coach
{
    public CoachId Id { get; }
    
    public string Name { get; }

    private Coach(CoachId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Coach Create(string name)
    {
        return new Coach(CoachId.New(), name);
    }
}