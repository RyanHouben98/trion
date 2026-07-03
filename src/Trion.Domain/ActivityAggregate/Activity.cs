using Trion.Domain.ActivityAggregate.ValueObjects;

namespace Trion.Domain.ActivityAggregate;

public sealed class Activity
{
    public ActivityId Id { get; }
    
    public string Title { get; }
    
    private  Activity(ActivityId id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Activity Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        
        return new Activity(ActivityId.New(), title);
    }
}