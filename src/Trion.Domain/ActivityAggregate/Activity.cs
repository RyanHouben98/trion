using Trion.Domain.ActivityAggregate.ValueObjects;

namespace Trion.Domain.ActivityAggregate;

public sealed class Activity
{
    public ActivityId Id { get; }
    
    public string Name { get; }
    
    private  Activity(ActivityId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Activity Create(string name)
    {
        return new Activity(ActivityId.New(), name);
    }
}