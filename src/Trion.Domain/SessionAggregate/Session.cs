using Trion.Domain.SessionAggregate.ValueObjects;

namespace Trion.Domain.SessionAggregate;

public sealed class Session
{
    public SessionId Id { get; }
    
    public string Title { get; }
    
    private  Session(SessionId id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Session Create(string title)
    {
        return new Session(SessionId.New(), title);
    }
}