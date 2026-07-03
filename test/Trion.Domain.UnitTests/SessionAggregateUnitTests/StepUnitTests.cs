using FluentAssertions;
using Trion.Domain.SessionAggregate.Entities;

namespace Trion.Domain.UnitTests.SessionAggregateUnitTests;

public class StepUnitTests
{
    [Fact]
    public void Create_ShouldCreateStep_WhenTitleIsValid()
    {
        var step = Step.Create();
        
        step.Id.Should().NotBe(Guid.Empty);
    }
}