using AZ.Core.DTOs;
using AZ.Infrastructure.Interfaces.IProviders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Providers
{
    public class LogQueueProvider : ILogQueueProvider
    {
        private readonly ConcurrentQueue<LogEntry> _logs = new();

        public void Enqueue(LogEntry log)
        {
            _logs.Enqueue(log);
        }

        public bool TryDequeue(out LogEntry log)
        {
            return _logs.TryDequeue(out log);
        }
    }
}
