using AZ.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface ILogRepository
    {
        Task AddAsync(LogEntry entry);
    }
}
