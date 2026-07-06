using Trion.Domain.PlanAggregate.ValueObjects;

namespace Trion.Domain.PlanAggregate.Entities;

public sealed class Block
{
    public BlockId Id { get; }
    
    public string Title { get; }
    
    private Block(BlockId id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Block Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        
        return new Block(BlockId.New(), title);
    }
}