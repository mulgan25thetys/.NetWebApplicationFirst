
namespace WebApplication1.Controllers.Logger
{
    public class CustomLogger : ILogger
    {
        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            return null;
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.Trace;
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"[{DateTime.Now}]: #{logLevel.ToString()}# {formatter(state, exception)}");
        }
    }
}
