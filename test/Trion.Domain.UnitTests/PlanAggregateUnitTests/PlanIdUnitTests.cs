using FluentAssertions;
using Trion.Domain.PlanAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.PlanAggregateUnitTests;

public class PlanIdUnitTests
{
    [Fact]
    public void New_ShouldCreatePlanId()
    {
        var planId = PlanId.New();
        
        planId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreatePlanId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var planId = PlanId.From(value);
        
        planId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoPlanIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var planIdOne = PlanId.From(value);
        var planIdTwo = PlanId.From(value);
        
        planIdOne.Should().Be(planIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => PlanId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}