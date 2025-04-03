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
    public class CategoryPermissionConfiguration : IEntityTypeConfiguration<CategoryPermission>
    {
        public void Configure(EntityTypeBuilder<CategoryPermission> builder)
        {
            // Đặt tên bảng
            builder.ToTable("CategoryPermissions");

            // Khóa chính
            builder.HasKey(cp => cp.Id);

            // Cấu hình các cột
            builder.Property(cp => cp.UserId)
                .IsRequired();

            builder.Property(cp => cp.CategoryId)
                .IsRequired();

            builder.Property(cp => cp.RoleId)
                .IsRequired();

            // Quan hệ với User (Nhiều CategoryPermission có thể thuộc về 1 User)
            builder.HasOne(cp => cp.User)
                .WithMany(u => u.CategoryPermissions)
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa user, tất cả quyền thuộc user sẽ bị xóa

            // Quan hệ với Category (Nhiều CategoryPermission có thể thuộc về 1 Category)
            builder.HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryPermissions)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa category, tất cả quyền trong category sẽ bị xóa

            // Quan hệ với Role (Nhiều CategoryPermission có thể thuộc về 1 Role)
            builder.HasOne(cp => cp.Role)
                .WithMany(r => r.CategoryPermissions)
                .HasForeignKey(cp => cp.RoleId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa role, tất cả quyền liên quan đến role sẽ bị xóa

            // Đánh index trên các cột quan trọng để tối ưu truy vấn
            builder.HasIndex(cp => new { cp.UserId, cp.CategoryId, cp.RoleId }).IsUnique(); // Mỗi user chỉ có quyền 1 lần cho mỗi category và role
        }
    }
}
