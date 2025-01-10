using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestProject1.Common
{
    public class XLoger : ILogger<LoggingDbCommandInterceptor>
    {
        private readonly ITestOutputHelper _output;

        public XLoger(ITestOutputHelper output)
        {
            _output = output;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null; // No scope handling for simplicity
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None; // Enable all log levels except None
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            var message = formatter(state, exception);
            if (exception != null)
            {
                message += $"\nException: {exception}";
            }

            _output.WriteLine($"[{logLevel}] {message}");
        }
    }


}
