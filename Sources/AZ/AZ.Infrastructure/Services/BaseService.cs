using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Interfaces.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class BaseService
    {
        //private readonly ILogger<T> _logger;
        protected readonly ILogQueueProvider _log;
        protected readonly IMappingProvider _mapping;
        protected BaseService(ILogQueueProvider log, IMappingProvider mapping)
        {
            _log = log;
            _mapping = mapping;
        }
    }
}
