using FluentAssertions;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.CoachAggregateUnitTests;

public class CoachIdUnitTests
{
    [Fact]
    public void New_ShouldCreateCoachId()
    {
        var coachId = CoachId.New();
        
        coachId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateCoachId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var coachId = CoachId.From(value);
        
        coachId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoCoachIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var coachIdOne = CoachId.From(value);
        var coachIdTwo = CoachId.From(value);
        
        coachIdOne.Should().Be(coachIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => CoachId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}