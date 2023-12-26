using System.Runtime.CompilerServices;

namespace AntiSpam.Core.Events;

public interface IEventPublisher
{
    void Raise<TEvent>(TEvent eventData, [CallerMemberName] string callerName = "")
        where TEvent : class, IDomainEvent;
}
