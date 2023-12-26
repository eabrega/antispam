using AntiSpam.Core.Events;

namespace AntiSpam.Core.Handlers;

public interface IHandler<in TEvent> where TEvent : IDomainEvent
{
    void Handle(TEvent businessEvent);
}