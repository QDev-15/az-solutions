using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Articles
{
    public class DTO_Rating
    {
        public int Id { get; set; }
        public DTO_Article Article { get; set; }
        public string IpAddress { set; get; }
        public int Score { get; set; }  // Score between 1-5, for example
        public DateTime RatedDate { get; set; }
        public UserResponse? User { get; set; }
    }
}
