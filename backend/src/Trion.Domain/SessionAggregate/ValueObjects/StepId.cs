namespace Trion.Domain.SessionAggregate.ValueObjects;

public sealed record StepId
{
    public Guid Value { get; }

    private StepId(Guid value)
    {
        Value = value;
    }

    public static StepId New()
    {
        return new StepId(Guid.NewGuid());
    }

    public static StepId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new StepId(value);
    }
}