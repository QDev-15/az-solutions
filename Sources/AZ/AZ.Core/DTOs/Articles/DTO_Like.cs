using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Articles
{
    public class DTO_Like
    {
        public int Id { get; set; }
        public DTO_Article? Article { get; set; }
        public int IpAddress { get; set; }
        public DateTime LikedDate { get; set; }
    }
}
