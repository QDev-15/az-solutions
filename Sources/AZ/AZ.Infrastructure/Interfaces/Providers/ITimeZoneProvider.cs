using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.Providers
{
    public interface ITimeZoneProvider
    {
        string GetTimeZoneId();
    }
}
