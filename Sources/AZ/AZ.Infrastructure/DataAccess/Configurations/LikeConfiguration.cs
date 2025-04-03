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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Likes");

            // Khóa chính
            builder.HasKey(l => l.Id);

            // Cấu hình các cột
            builder.Property(l => l.LikedDate)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow); // Tự động tạo thời gian khi like bài viết

            builder.Property(l => l.IpAddress)
                .IsRequired();      // IP người dùng xem bài viết

            // Quan hệ với Article
            builder.HasOne(l => l.Article)
                .WithMany(a => a.Likes)
                .HasForeignKey(l => l.ArticleId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa bài viết, tất cả like liên quan bị xóa

            // Đánh chỉ mục để tối ưu hóa việc tìm kiếm theo ArticleId và UserId
            builder.HasIndex(l => new { l.ArticleId, l.IpAddress }).IsUnique(); // Đảm bảo mỗi người dùng chỉ có một like cho mỗi bài viết
        }
    }
}
