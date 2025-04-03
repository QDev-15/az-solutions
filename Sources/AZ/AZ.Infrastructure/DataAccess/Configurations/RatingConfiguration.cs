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
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Score)
                .IsRequired();

            builder.Property(r => r.IpAddress)
                .HasMaxLength(45); // IPv6 tối đa 45 ký tự

            builder.HasIndex(r => r.ArticleId); // Tạo index để tối ưu tìm kiếm đánh giá của bài viết
            builder.HasIndex(r => r.IpAddress); // Tạo index để tối ưu tìm kiếm đánh giá của bài viết

            builder.HasOne(r => r.Article)
                .WithMany(a => a.Ratings)
                .HasForeignKey(r => r.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull); // Nếu user bị xóa, rating vẫn giữ lại
        }
    }

}
