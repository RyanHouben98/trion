namespace Trion.Domain.PlanAggregate.ValueObjects;

public sealed record BlockId
{
    public  Guid Value { get; }

    private BlockId(Guid value)
    {
        Value = value;
    }

    public static BlockId New()
    {
        return new BlockId(Guid.NewGuid());
    }

    public static BlockId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new BlockId(value);
    }
}