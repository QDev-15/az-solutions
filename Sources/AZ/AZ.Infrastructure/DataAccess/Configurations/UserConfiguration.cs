using AZ.Core.Enums;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Khóa chính
            builder.HasKey(u => u.Id);

            // Cấu hình các trường
            builder.Property(u => u.Username)
                .IsRequired() // Username là bắt buộc
                .HasMaxLength(100); // Giới hạn độ dài của username

            // Cấu hình các trường
            builder.Property(u => u.DisplayName)
                .IsRequired(false) // DisplayName là bắt buộc
                .HasMaxLength(100); // Giới hạn độ dài của username

            builder.Property(u => u.Email)
                .IsRequired() // Email là bắt buộc
                .HasMaxLength(100); // Giới hạn độ dài của email

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(15); // Giới hạn độ dài của số điện thoại

            builder.Property(u => u.PasswordHash)
                .IsRequired() // Password hash là bắt buộc
                .HasMaxLength(256); // Giới hạn độ dài cho hash password

            builder.Property(u => u.CreatedAt)
                .IsRequired() // Thời gian tạo là bắt buộc
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(u => u.UpdatedAt)
                .IsRequired() // Thời gian cập nhật là bắt buộc
                .HasDefaultValue(DateTime.UtcNow);

            // Cấu hình thuộc tính Status
            builder.Property(u => u.Status)
                .IsRequired(false) // Status là bắt buộc
                .HasDefaultValue(UserStatus.InActive)
                .HasConversion<string>(); // Lưu giá trị enum dưới dạng string (hoặc bạn có thể dùng int nếu muốn)

            // Cấu hình mối quan hệ với bảng Media (Avatar)
            builder.HasOne(u => u.Avatar)
                .WithMany() // Một Avatar có thể được nhiều người dùng sử dụng
                .HasForeignKey(u => u.AvatarId)
                .OnDelete(DeleteBehavior.SetNull); // Khi xóa ảnh đại diện, không xóa người dùng

            // Cấu hình mối quan hệ với bảng UserRole
            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Khi người dùng bị xóa, vai trò của người dùng sẽ bị xóa

            // Cấu hình mối quan hệ với bảng Article
            builder.HasMany(u => u.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // Khi xóa hết bài viết mới xóa người dùng

            // Cấu hình mối quan hệ với bảng Rating
            builder.HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Khi người dùng bị xóa, các đánh giá của họ sẽ bị xóa

            // Cấu hình mối quan hệ với bảng CategoryPermission
            builder.HasMany(u => u.CategoryPermissions)
                .WithOne(cp => cp.User)
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Khi người dùng bị xóa, quyền của họ đối với chuyên mục sẽ bị xóa

            // Tạo chỉ mục cho Email để tìm kiếm nhanh
            builder.HasIndex(u => u.Email).IsUnique(); // Đảm bảo rằng email là duy nhất

            // Tạo chỉ mục cho Username để tìm kiếm nhanh
            builder.HasIndex(u => u.Username).IsUnique(); // Đảm bảo rằng username là duy nhất
        }
    }
}
