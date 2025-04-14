using AZ.Core.DTOs;
using AZ.Infrastructure.Interfaces.IProviders;
using Microsoft.Extensions.Logging;

namespace AZ.Infrastructure.Extentions
{
    public static class LogExtensition
    {
        public static void LogError(this ILogQueueProvider queue, string message, string? source = null, string? stackTrace = null)
        {
            queue.Enqueue(new LogEntry
            {
                Message = message,
                Source = source,
                StackTrace = stackTrace,
                Level = LogLevel.Error.ToString()
            });
        }

        public static void LogInfo(this ILogQueueProvider queue, string message, string? source = null)
        {
            queue.Enqueue(new LogEntry
            {
                Message = message,
                Source = source,
                Level = LogLevel.Information.ToString()
            });
        }
    }

}
