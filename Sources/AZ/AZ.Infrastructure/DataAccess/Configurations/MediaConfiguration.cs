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
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Media");

            // Khóa chính
            builder.HasKey(m => m.Id);

            // Cấu hình các cột
            builder.Property(m => m.FilePath)
                .IsRequired() // Đảm bảo đường dẫn tệp là bắt buộc
                .HasMaxLength(1000); // Giới hạn độ dài của FilePath

            builder.Property(m => m.AltText)
                .HasMaxLength(500); // Giới hạn độ dài của AltText

            builder.Property(m => m.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow); // Tự động tạo thời gian khi tạo media

            builder.Property(m => m.UpdatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow); // Tự động tạo thời gian khi cập nhật media

        }
    }
}
