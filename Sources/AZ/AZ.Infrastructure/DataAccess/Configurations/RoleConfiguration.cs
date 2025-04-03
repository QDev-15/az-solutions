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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Description)
                .HasMaxLength(500);

            builder.Property(r => r.RoleType)
                .IsRequired()
                .HasDefaultValue(RoleType.User)
                .HasConversion<string>(); // Lưu enum dưới dạng string để dễ đọc
           
            builder.HasIndex(r => r.Name)
                .IsUnique(); // Đảm bảo không có hai vai trò trùng tên

            builder.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.CategoryPermissions)
                .WithOne(cp => cp.Role)
                .HasForeignKey(cp => cp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
