namespace Trion.Domain.CoachAggregate.ValueObjects;

public sealed record CoachId
{
    public Guid Value { get; }

    private CoachId(Guid value)
    {
        Value = value;
    }

    public static CoachId New()
    {
        return new CoachId(Guid.NewGuid());
    }

    public static CoachId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));

        return new CoachId(value);
    }
}