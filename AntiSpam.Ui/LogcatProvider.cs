using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace AntiSpam.Ui
{
    [UnsupportedOSPlatform("browser")]
    [ProviderAlias("ColorConsole")]
    public class LogcatProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, Logcat> _loggers =
            new(StringComparer.OrdinalIgnoreCase);

        public ILogger CreateLogger(string categoryName)=>
            _loggers.GetOrAdd(categoryName, name => new Logcat());
        

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
