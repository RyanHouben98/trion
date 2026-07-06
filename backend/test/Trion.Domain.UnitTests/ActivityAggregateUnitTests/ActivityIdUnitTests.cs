using FluentAssertions;
using Trion.Domain.ActivityAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.ActivityAggregateUnitTests;

public class ActivityIdUnitTests
{
    [Fact]
    public void New_ShouldCreateActivityId()
    {
        var coachId = ActivityId.New();
        
        coachId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateActivityId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var coachId = ActivityId.From(value);
        
        coachId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoActivityIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var coachIdOne = ActivityId.From(value);
        var coachIdTwo = ActivityId.From(value);
        
        coachIdOne.Should().Be(coachIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => ActivityId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}