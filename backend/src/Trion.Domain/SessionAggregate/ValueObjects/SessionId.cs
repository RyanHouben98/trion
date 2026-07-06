namespace Trion.Domain.SessionAggregate.ValueObjects;

public sealed record SessionId
{
    public Guid Value { get; }

    private SessionId(Guid value)
    {
        Value = value;
    }

    public static SessionId New()
    {
        return new SessionId(Guid.NewGuid());
    }

    public static SessionId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new SessionId(value);
    }
}