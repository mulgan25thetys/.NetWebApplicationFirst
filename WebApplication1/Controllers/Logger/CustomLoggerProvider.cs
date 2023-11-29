using System.Collections.Concurrent;

namespace WebApplication1.Controllers.Logger
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();
        public ILogger CreateLogger(string categoryName)
        {
            this._loggers.GetOrAdd(categoryName, key => new CustomLogger());

            return this._loggers[categoryName];
        }

        public void Dispose()
        {
            this._loggers.Clear();
        }
    }
}
