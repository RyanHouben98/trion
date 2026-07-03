using FluentAssertions;
using Trion.Domain.ActivityAggregate;

namespace Trion.Domain.UnitTests.ActivityAggregateUnitTests;

public class ActivityUnitTests
{
    [Fact]
    public void Create_ShouldCreateAthlete_WhenTitleIsValid()
    {
        const string title = "Intervall session";

        var coach = Activity.Create(title);
        
        coach.Id.Should().NotBe(Guid.Empty);
        coach.Title.Should().Be(title);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenTitleIsNullOrWhiteSpace(string? title)
    {
        var act = () => Activity.Create(title);
        
        act.Should().Throw<ArgumentNullException>();
    }
}