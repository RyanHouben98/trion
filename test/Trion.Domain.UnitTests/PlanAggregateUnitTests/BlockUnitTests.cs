using FluentAssertions;
using Trion.Domain.PlanAggregate.Entities;

namespace Trion.Domain.UnitTests.PlanAggregateUnitTests;

public class BlockUnitTests
{
    [Fact]
    public void Create_ShouldCreateBlock_WhenTitleIsValid()
    {
        const string title = "Aerobe build phase";

        var block = Block.Create(title);
        
        block.Id.Should().NotBe(Guid.Empty);
        block.Title.Should().Be(title);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_ShouldThrowArgumentException_WhenTitleIsNullOrWhiteSpace(string? title)
    {
        var act = () => Block.Create(title);
        
        act.Should().Throw<ArgumentNullException>();
    }
}