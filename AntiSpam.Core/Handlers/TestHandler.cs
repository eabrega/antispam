using AntiSpam.Core.Events;
using Microsoft.Extensions.Logging;

namespace AntiSpam.Core.Handlers;

public class TestHandler : IHandler<TestEvent>
{
    private readonly ILogger<TestHandler> _logger;

    public TestHandler(ILogger<TestHandler> logger)
    {
        _logger = logger;
    }

    void IHandler<TestEvent>.Handle(TestEvent businessEvent)
    {
        _logger.LogInformation("EVENT {Value}",  businessEvent.Value);
    }
}