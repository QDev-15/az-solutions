using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.Enums
{
    public enum FeedbackStatus
    {
        Pending,     // Chờ xử lý
        InProgress,  // Đang xử lý
        Resolved,    // Đã giải quyết
        Closed       // Đã đóng
    }
}
