using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Khóa chính
            builder.HasKey(ur => ur.Id);

            // Cấu hình các mối quan hệ
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles) // Một người dùng có thể có nhiều vai trò
                .HasForeignKey(ur => ur.UserId) // Mối quan hệ với UserId
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa người dùng, các vai trò của người dùng cũng bị xóa

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles) // Một vai trò có thể gắn với nhiều người dùng
                .HasForeignKey(ur => ur.RoleId) // Mối quan hệ với RoleId
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa vai trò, các vai trò của người dùng cũng bị xóa

            // Tạo chỉ mục cho UserId và RoleId
            builder.HasIndex(ur => new { ur.UserId, ur.RoleId }).IsUnique(); // Đảm bảo rằng mỗi người dùng chỉ có một vai trò duy nhất
        }
    }
}
