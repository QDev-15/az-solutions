using AZ.Core.DTOs;
using AZ.Core.Enums;
using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly AZDbContext _context;

        public LogRepository(AZDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LogEntry entry)
        {
            var log = new Log
            {
                Message = entry.Message,
                Source = entry.Source,
                StackTrace = entry.StackTrace,
                Level = entry.Level.ToString(),
                CreatedAt = entry.CreatedAt
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }

}
