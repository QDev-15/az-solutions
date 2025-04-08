using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ArticleTranslationConfiguration : IEntityTypeConfiguration<ArticleTranslation>
{
    public void Configure(EntityTypeBuilder<ArticleTranslation> builder)
    {
        // Đặt tên bảng
        builder.ToTable("ArticleTranslations");

        // Khóa chính
        builder.HasKey(at => at.Id);

        // Cấu hình các cột
        builder.Property(at => at.LanguageCode)
            .IsRequired()
            .HasMaxLength(10); // ISO language code (e.g., en, vi, ja, ko)

        builder.Property(at => at.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(at => at.Content)
            .IsRequired();

        builder.Property(at => at.Slug)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(at => at.MetaTitle)
            .HasMaxLength(255);

        builder.Property(at => at.MetaDescription)
            .HasMaxLength(500);

        builder.Property(at => at.MetaKeywords)
            .HasMaxLength(500);

        // Thiết lập quan hệ với Article (1-n)
        builder.HasOne(at => at.Article)
            .WithMany(a => a.ArticleTranslations)
            .HasForeignKey(at => at.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Language)
            .WithMany()
            .HasForeignKey(l => l.LanguageCode)
            .OnDelete(DeleteBehavior.Restrict);

        // Thiết lập quan hệ với Media (Ảnh Open Graph, n-1)
        builder.HasOne(at => at.OgImage)
            .WithMany()
            .HasForeignKey(at => at.OgImageId)
            .OnDelete(DeleteBehavior.SetNull); // Không xóa bản dịch nếu ảnh bị xóa

        // Đánh Index để tối ưu tìm kiếm và SEO
        builder.HasIndex(at => new { at.ArticleId, at.LanguageCode }).IsUnique();
        builder.HasIndex(at => at.Slug).IsUnique();
    }
}
