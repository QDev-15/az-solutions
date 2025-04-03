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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            
            // Đặt tên bảng
            builder.ToTable("Tags");

            // Đảm bảo các trường Name và Alias không để null
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255); // Có thể điều chỉnh độ dài tùy theo yêu cầu

            builder.Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(255); // Đảm bảo Alias cũng không null và có độ dài hợp lý
                                    // Đặt chỉ mục cho Name và Slug để tối ưu hóa tìm kiếm
            builder.HasIndex(t => t.Name).HasName("IX_Tag_Name").IsUnique();
            builder.HasIndex(t => t.Slug).HasName("IX_Tag_Slug").IsUnique();
        }
    }

}
