using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.Enums
{
    public enum RoleType
    {
        System, // Vai trò dành cho hệ thống (Super Admin, API Access...)
        Admin,  // Vai trò quản trị (Quản lý bài viết, người dùng...)
        User    // Vai trò của người dùng thông thường
    }
}
