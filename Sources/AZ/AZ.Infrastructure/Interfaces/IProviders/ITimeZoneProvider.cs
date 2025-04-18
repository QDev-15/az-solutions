using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IProviders
{
    public interface ITimeZoneProvider
    {
        string GetTimeZoneId();
        string GetLanguageCode();
    }
}
