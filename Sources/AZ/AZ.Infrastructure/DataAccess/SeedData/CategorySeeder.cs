using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { 
                    Id = 1, 
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,
                    CategoryTranslations = [
                        new CategoryTranslation() {
                            Id = 1,
                            LanguageCode = "vi",
                            Name = "Liên hệ",
                            Slug = "lien-he",
                            Description = "Liên hệ"
                        },
                        new CategoryTranslation() {
                            Id = 2,
                            LanguageCode = "en",
                            Name = "Contact",
                            Slug = "contact",
                            Description = "contact"
                        }
                    ]
                },
                new Category()
                {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CategoryTranslations = [
                        new CategoryTranslation() {
                            Id = 3,
                            LanguageCode = "vi",
                            Name = "Giới thiệu",
                            Slug = "gioi-thieu",
                            Description = "giới thiệu"
                        },
                        new CategoryTranslation() {
                            Id = 4,
                            LanguageCode = "en",
                            Name = "About",
                            Slug = "about",
                            Description = "about"
                        }
                    ]
                }
            );
        }
    }
}
