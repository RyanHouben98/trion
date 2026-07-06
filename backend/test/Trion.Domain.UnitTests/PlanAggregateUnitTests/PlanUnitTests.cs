using FluentAssertions;
using Trion.Domain.PlanAggregate;

namespace Trion.Domain.UnitTests.PlanAggregateUnitTests;

public class PlanUnitTests
{
    [Fact]
    public void Create_ShouldCreatePlan_WhenTitleIsValid()
    {
        const string title = "Ironman 70.3";

        var plan = Plan.Create(title);
        
        plan.Id.Should().NotBe(Guid.Empty);
        plan.Title.Should().Be(title);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenTitleIsNullOrWhiteSpace(string? title)
    {
        var act = () => Plan.Create(title);
        
        act.Should().Throw<ArgumentNullException>();
    }
}