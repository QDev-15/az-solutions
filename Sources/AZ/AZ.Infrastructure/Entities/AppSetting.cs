using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string? Key { get; set; }  // Tên cấu hình
        public string? Value { get; set; }  // Giá trị cấu hình
        public string? Description { get; set; }  // Mô tả cấu hình
    }

}
