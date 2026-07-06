using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Domain.CoachAggregate;

public sealed class Coach
{
    public CoachId Id { get; }
    
    public string Name { get; private set; }
    
    /**
     * Empty constructor used for EF Core.
     */
    private Coach() { }

    private Coach(CoachId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Coach Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
            
        return new Coach(CoachId.New(), name);
    }
    
    public void Update(string name)
    {
        Name = name;
    }
}