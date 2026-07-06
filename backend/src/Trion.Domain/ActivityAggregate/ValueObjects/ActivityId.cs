namespace Trion.Domain.ActivityAggregate.ValueObjects;

public sealed record ActivityId
{
    public Guid Value { get; }

    private ActivityId(Guid value)
    {
        Value = value;
    }

    public static ActivityId New()
    {
        return new ActivityId(Guid.NewGuid());
    }

    public static ActivityId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new ActivityId(value);
    }
}