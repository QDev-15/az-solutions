using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class TrafficStatistic
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PageUrl { get; set; }
        public int Views { get; set; }
        public int UniqueVisitors { get; set; }
    }

}
