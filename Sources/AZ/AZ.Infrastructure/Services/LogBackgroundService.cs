using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class LogBackgroundService : BackgroundService
    {
        private readonly ILogQueueProvider _logQueue;
        private readonly IServiceScopeFactory _scopeFactory;

        public LogBackgroundService(ILogQueueProvider logQueue, IServiceScopeFactory scopeFactory)
        {
            _logQueue = logQueue;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logQueue.TryDequeue(out var log))
                {
                    using var scope = _scopeFactory.CreateScope();
                    var logRepo = scope.ServiceProvider.GetRequiredService<ILogRepository>();
                    await logRepo.AddAsync(log);
                }
                else
                {
                    await Task.Delay(500); // giảm tải CPU
                }
            }
        }
    }

}
