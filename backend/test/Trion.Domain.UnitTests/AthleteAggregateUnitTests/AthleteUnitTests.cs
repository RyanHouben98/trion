using FluentAssertions;
using Trion.Domain.AthleteAggregate;

namespace Trion.Domain.UnitTests.AthleteAggregateUnitTests;

public class AthleteUnitTests
{
    [Fact]
    public void Create_ShouldCreateAthlete_WhenNameIsValid()
    {
        const string name = "John Doe";

        var coach = Athlete.Create(name);
        
        coach.Id.Should().NotBe(Guid.Empty);
        coach.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenNameIsNullOrWhiteSpace(string? name)
    {
        var act = () => Athlete.Create(name);
        
        act.Should().Throw<ArgumentNullException>();
    }
}