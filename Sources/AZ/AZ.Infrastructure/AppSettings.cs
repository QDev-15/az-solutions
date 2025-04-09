using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure
{
    public class AppSettingsConnectionStrings
    {
        public string Connection { set; get; }
    }
    public class AppSettingsJwt
    {
        public string Key {set;get;}
        public string Issuer {set;get;}
        public string Audience {set;get;}
        public int AccessTokenExpirationMinutes { set; get; } = 1440;
        public int RefreshTokenExpirationDays { set; get; } = 7;
    }
}
