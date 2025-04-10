using AZ.Infrastructure.Interfaces.Providers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Providers
{
    public class TimeZoneProvider : ITimeZoneProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TimeZoneProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTimeZoneId()
        {
            var headerValue = _httpContextAccessor.HttpContext?.Request?.Headers["TimeZone"].ToString();
            return string.IsNullOrWhiteSpace(headerValue) ? "SE Asia Standard Time" : headerValue;
        }
    }
}
