namespace Trion.Domain.AthleteAggregate.ValueObjects;

public sealed record AthleteId
{
    public Guid Value { get; }

    private AthleteId(Guid value)
    {   
        Value = value;
    }

    public static AthleteId New()
    {
        return new AthleteId(Guid.NewGuid());
    }
    
    public static AthleteId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty", nameof(value));
        
        return new AthleteId(value);
    }
}