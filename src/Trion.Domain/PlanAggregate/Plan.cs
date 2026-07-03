using Trion.Domain.PlanAggregate.ValueObjects;

namespace Trion.Domain.PlanAggregate;

public sealed class Plan
{
    public PlanId Id { get; }
    
    public string Title { get; }

    private Plan(PlanId id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Plan Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        
        return new Plan(PlanId.New(), title);
    }
}