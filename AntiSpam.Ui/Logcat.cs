using Microsoft.Extensions.Logging;

#if ANDROID
using Android.Util;
#endif

namespace AntiSpam.Ui
{
    public class Logcat : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull =>
            default;

        public bool IsEnabled(LogLevel logLevel) =>
            true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            
#if ANDROID
            Android.Util.Log.Info(logLevel.ToString(), $"{formatter(state, exception)}");
#endif
        }
    }
}
