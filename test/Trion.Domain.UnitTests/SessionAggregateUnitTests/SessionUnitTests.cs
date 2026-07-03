using FluentAssertions;
using Trion.Domain.SessionAggregate;

namespace Trion.Domain.UnitTests.SessionAggregateUnitTests;

public class SessionUnitTests
{
    [Fact]
    public void Create_ShouldCreateSession_WhenTitleIsValid()
    {
        const string title = "Aerobe build phase";

        var session = Session.Create(title);
        
        session.Id.Should().NotBe(Guid.Empty);
        session.Title.Should().Be(title);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenTitleIsNullOrWhiteSpace(string? title)
    {
        var act = () => Session.Create(title);
        
        act.Should().Throw<ArgumentNullException>();
    }
}