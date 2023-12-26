using AntiSpam.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace AntiSpam.Core.Handlers;

public class EventHandlersChain<TDomainEvent> where TDomainEvent : IDomainEvent
{
    private readonly IServiceCollection _serviceCollection;

    public EventHandlersChain(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public EventHandlersChain<TDomainEvent> WithHandler<THandler>()
        where THandler : class, IHandler<TDomainEvent>
    {
        _serviceCollection.AddScoped<IHandler<TDomainEvent>, THandler>();

        return new EventHandlersChain<TDomainEvent>(_serviceCollection);
    }
}
