using FluentAssertions;
using Trion.Domain.SessionAggregate.ValueObjects;

namespace Trion.Domain.UnitTests.SessionAggregateUnitTests;

public class SessionIdUnitTests
{
    [Fact]
    public void New_ShouldCreateSessionId()
    {
        var sessionId = SessionId.New();
        
        sessionId.Value.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void From_ShouldCreateSessionId_WhenGuidIsValid()
    {
        var value = Guid.NewGuid();
            
        var sessionId = SessionId.From(value);
        
        sessionId.Value.Should().Be(value);
    }
    
    [Fact]
    public void TwoSessionIds_ShouldBeEqual()
    {
        var value = Guid.NewGuid();
        
        var sessionIdOne = SessionId.From(value);
        var sessionIdTwo = SessionId.From(value);
        
        sessionIdOne.Should().Be(sessionIdTwo);
    }

    [Fact]
    public void From_ShouldThrowArgumentException_WhenValueEmptyGuid()
    {
        var act = () => SessionId.From(Guid.Empty);
        
        act.Should().Throw<ArgumentException>();
    }
}