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
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Logs");

            // Khóa chính
            builder.HasKey(l => l.Id);

            builder.Property(l => l.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow); // Tự động tạo thời gian khi tạo log

            builder.Property(l => l.IpAddress)
                .HasMaxLength(50); // Giới hạn độ dài cho IP address (tùy thuộc vào format IP)

            // Đánh chỉ mục trên cột CreatedAt để tối ưu hóa việc tìm kiếm theo thời gian
            builder.HasIndex(l => l.CreatedAt);
        }
    }
}
