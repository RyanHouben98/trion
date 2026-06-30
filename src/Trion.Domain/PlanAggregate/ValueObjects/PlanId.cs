namespace Trion.Domain.PlanAggregate.ValueObjects;

public sealed record PlanId
{
    public Guid Value { get; }

    private PlanId(Guid value)
    {
        Value = value;
    }

    public static PlanId New()
    {
        return new PlanId(Guid.NewGuid());
    }

    public static PlanId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new PlanId(value);
    }
}