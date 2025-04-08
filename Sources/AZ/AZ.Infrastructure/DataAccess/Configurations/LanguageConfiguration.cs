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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Code);

            builder.Property(l => l.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.NativeName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.IsDefault)
                .HasDefaultValue(false);

            builder.Property(l => l.IsEnabled)
                .HasDefaultValue(true);
        }
    }
}
