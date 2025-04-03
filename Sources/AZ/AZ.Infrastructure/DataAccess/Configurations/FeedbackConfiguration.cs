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
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Feedbacks");

            // Khóa chính
            builder.HasKey(f => f.Id);

            // Cấu hình các cột
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.Phone)
                .HasMaxLength(20); // Số điện thoại có thể dài hơn, tùy thuộc vào quốc gia

            builder.Property(f => f.Message)
                .IsRequired()
                .HasMaxLength(1000); // Mã giới hạn độ dài cho tin nhắn

            builder.Property(f => f.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow); // Tự động tạo thời gian khi tạo mới

            builder.Property(f => f.Status)
                .IsRequired()
                .HasDefaultValue(FeedbackStatus.Pending)
                .HasConversion<string>(); // Chuyển enum sang string để lưu trữ

            // Đánh chỉ mục trên Email và Status để tìm kiếm nhanh
            builder.HasIndex(f => new { f.Email, f.Status });
        }
    }
}
