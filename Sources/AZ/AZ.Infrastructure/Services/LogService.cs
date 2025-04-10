using AZ.Core.DTOs;
using AZ.Infrastructure.Interfaces.Providers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public static class LogService
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
