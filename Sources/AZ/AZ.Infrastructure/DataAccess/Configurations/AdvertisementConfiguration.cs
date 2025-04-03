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
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Advertisements");

            // Khóa chính
            builder.HasKey(a => a.Id);

            // Cấu hình các cột
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.TargetUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Position)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.StartDate)
                .IsRequired();

            builder.Property(a => a.EndDate)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Đánh Index để tối ưu tìm kiếm quảng cáo
            builder.HasIndex(a => a.Position);
            builder.HasIndex(a => a.StartDate);
            builder.HasIndex(a => a.EndDate);
        }
    }
}
