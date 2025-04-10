using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs
{
    public class LogEntry
    {
        public string Message { get; set; } = string.Empty;
        public string? Source { get; set; }
        public string Level { get; set; }
        public string? StackTrace { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
