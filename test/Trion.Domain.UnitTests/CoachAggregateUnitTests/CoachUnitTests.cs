using FluentAssertions;
using Trion.Domain.CoachAggregate;

namespace Trion.Domain.UnitTests.CoachAggregateUnitTests;

public class CoachUnitTests
{
    [Fact]
    public void Create_ShouldCreateCoach_WhenNameIsValid()
    {
        const string name = "John Doe";

        var coach = Coach.Create(name);
        
        coach.Id.Should().NotBe(Guid.Empty);
        coach.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenNameIsNullOrWhiteSpace(string? name)
    {
        var act = () =>  Coach.Create(name);
        
        act.Should().Throw<ArgumentNullException>();
    }
}