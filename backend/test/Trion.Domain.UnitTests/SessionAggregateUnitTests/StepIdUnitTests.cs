using FluentAssertions;
using Trion.Domain.SessionAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.SessionAggregateUnitTests;

public class StepIdUnitTests
{
    [Fact]
    public void New_ShouldCreateStepId()
    {
        var stepId = StepId.New();
        
        stepId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateStepId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var stepId = StepId.From(value);
        
        stepId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoStepIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var stepIdOne = StepId.From(value);
        var stepIdTwo = StepId.From(value);
        
        stepIdOne.Should().Be(stepIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => StepId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}