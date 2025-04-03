using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AZ.Infrastructure.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Categories");

            // Khóa chính
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .IsRequired();

            // Định nghĩa quan hệ đệ quy: Một Category có thể có một Category cha
            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Tránh xóa đệ quy gây lỗi

            // Quan hệ với bảng Articles (Một category có nhiều articles)
            builder.HasMany(c => c.Articles)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Xóa category => Xóa bài viết

            // Quan hệ với CategoryPermissions
            builder.HasMany(c => c.CategoryPermissions)
                .WithOne(cp => cp.Category)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ với CategoryTranslations (Đa ngôn ngữ)
            builder.HasMany(c => c.CategoryTranslations)
                .WithOne(ct => ct.Category)
                .HasForeignKey(ct => ct.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}