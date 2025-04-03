using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public string IpAddress { set; get; }
        public int Score { get; set; }  // Score between 1-5, for example
        public DateTime RatedDate { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }

}
