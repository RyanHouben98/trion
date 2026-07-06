using Trion.Domain.SessionAggregate.ValueObjects;

namespace Trion.Domain.SessionAggregate.Entities;

public sealed class Step
{
    public StepId Id { get; }
    
    private Step(StepId id)
    {
        Id = id;
    }

    public static Step Create()
    {
        return new Step(StepId.New());
    }
}