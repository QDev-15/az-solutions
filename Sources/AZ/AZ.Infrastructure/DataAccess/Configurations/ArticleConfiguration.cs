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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn().IsRequired(true);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Alias).IsRequired(true);
            builder.Property(a => a.AuthorId).IsRequired(true);
            builder.Property(a => a.Status).IsRequired(true).HasDefaultValue(ArticleStatus.Draft);
            builder.Property(a => a.Views).HasDefaultValue(0);
            builder.Property(a => a.RatingResult).IsRequired(true).HasDefaultValue(0);

            builder.HasIndex(a => a.Id).IsUnique(true);
            builder.HasIndex(a => a.Title).IsUnique(true);
            builder.HasIndex(a => a.Alias).IsUnique(true);


            builder.HasOne(a => a.Thumbnail)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.ThumbnailId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId).IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Author).WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId).IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ nhiều-nhiều giữa Articles và Tags
            builder.HasMany(a => a.Tags)
                .WithMany(t => t.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleTag", // Tên bảng trung gian
                    j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.Cascade));
        }
    }
}
