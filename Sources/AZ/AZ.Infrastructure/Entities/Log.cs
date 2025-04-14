using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Source { get; set; }
        public string? Level { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? IpAddress { get; set; }
    }

}
