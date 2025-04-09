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
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            // Configure table name
            builder.ToTable("AppSettings");

            // Configure primary key
            builder.HasKey(a => a.Id);

            // Configure properties
            builder.Property(a => a.Key)
                .IsRequired()
                .HasMaxLength(100);  // Có thể thay đổi chiều dài tối đa nếu cần

            builder.Property(a => a.Value)
                .IsRequired()
                .HasMaxLength(500);  // Tùy thuộc vào chiều dài của các giá trị cấu hình

            builder.Property(a => a.Description)
                .HasMaxLength(500);  // Mô tả có thể không phải là trường bắt buộc, nên không cần thiết phải chỉ định `IsRequired`

            // Add Index for Key for faster lookups
            builder.HasIndex(a => a.Key)
                .IsUnique();  // Giả sử mỗi cấu hình có Key duy nhất

        }
    }

}
