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
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            // Đặt tên bảng
            builder.ToTable("CategoryTranslations");

            // Khóa chính
            builder.HasKey(ct => ct.Id);

            // Cấu hình các cột
            builder.Property(ct => ct.LanguageCode)
                .IsRequired()
                .HasMaxLength(10); // Ví dụ: 'en', 'vi', 'ja', ...

            builder.Property(ct => ct.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ct => ct.Description)
                .HasMaxLength(1000); // Mô tả có thể dài hơn

            builder.Property(ct => ct.Slug)
                .HasMaxLength(255);

            builder.Property(ct => ct.MetaTitle)
                .HasMaxLength(255);

            builder.Property(ct => ct.MetaDescription)
                .HasMaxLength(1000);

            builder.Property(ct => ct.MetaKeywords)
                .HasMaxLength(500);

            // Quan hệ với Category (Mỗi bản dịch thuộc về một Category)
            builder.HasOne(ct => ct.Category)
                .WithMany(c => c.CategoryTranslations)
                .HasForeignKey(ct => ct.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Category, tất cả bản dịch liên quan bị xóa

            // Đánh index tối ưu cho `LanguageCode` và `Slug` (Để tìm kiếm nhanh theo ngôn ngữ và slug)
            builder.HasIndex(ct => new { ct.LanguageCode, ct.Slug }).IsUnique(); // Đảm bảo không trùng slug cho mỗi ngôn ngữ
        }
    }
}
