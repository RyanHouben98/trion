using FluentAssertions;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.AthleteAggregateUnitTests;

public class AthleteIdUnitTests
{
    [Fact]
    public void New_ShouldCreateAthleteId()
    {
        var coachId = AthleteId.New();
        
        coachId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateAthleteId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var coachId = AthleteId.From(value);
        
        coachId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoAthleteIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var coachIdOne = AthleteId.From(value);
        var coachIdTwo = AthleteId.From(value);
        
        coachIdOne.Should().Be(coachIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => AthleteId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}