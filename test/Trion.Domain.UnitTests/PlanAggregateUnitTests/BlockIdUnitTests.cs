using FluentAssertions;
using Trion.Domain.PlanAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.PlanAggregateUnitTests;

public class BlockIdUnitTests
{
    [Fact]
    public void New_ShouldCreateBlockId()
    {
        var blockId = BlockId.New();
        
        blockId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateBlockId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var blockId = BlockId.From(value);
        
        blockId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoBlockIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var blockIdOne = BlockId.From(value);
        var blockIdTwo = BlockId.From(value);
        
        blockIdOne.Should().Be(blockIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => BlockId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}