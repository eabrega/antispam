using AntiSpam.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace AntiSpam.Core.Handlers;

public static class DomainEventHandlersDiRegistration
{
    public static IServiceCollection RegisterDomainEventHandlers(
        this IServiceCollection services)
    {
        services
            .AddEvent<TestEvent>()
            .WithHandler<TestHandler>();

        return services;
    }

    private static EventHandlersChain<TDomainEvent> AddEvent<TDomainEvent>(
        this IServiceCollection services)
        where TDomainEvent : IDomainEvent
    {
        return new EventHandlersChain<TDomainEvent>(services);
    }
}
