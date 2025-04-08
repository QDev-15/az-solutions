using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class LanguageSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Code = "vi", DisplayName = "Vietnamese", NativeName = "Tiếng Việt", IsDefault = true, IsEnabled = true },
                new Language { Code = "en", DisplayName = "English", NativeName = "English", IsDefault = false, IsEnabled = true }
            );
        }
    }
}
