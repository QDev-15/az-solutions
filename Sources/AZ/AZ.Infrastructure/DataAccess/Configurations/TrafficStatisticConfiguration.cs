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
    public class TrafficStatisticConfiguration : IEntityTypeConfiguration<TrafficStatistic>
    {
        public void Configure(EntityTypeBuilder<TrafficStatistic> builder)
        {
            // Đặt tên bảng
            builder.ToTable("TrafficStatistics");

            // Đảm bảo trường PageUrl có độ dài hợp lý
            builder.Property(ts => ts.PageUrl)
                .IsRequired()
                .HasMaxLength(2048); // Đảm bảo không vượt quá giới hạn URL thông thường

            // Đảm bảo trường Date là duy nhất cho mỗi ngày và trang
            builder.HasIndex(ts => new { ts.Date, ts.PageUrl })
                .HasName("IX_TrafficStatistic_Date_PageUrl")
                .IsUnique();

            // Đặt các trường Views và UniqueVisitors có giá trị mặc định là 0 nếu không được cung cấp
            builder.Property(ts => ts.Views)
                .HasDefaultValue(0);

            builder.Property(ts => ts.UniqueVisitors)
                .HasDefaultValue(0);
        }
    }
}
