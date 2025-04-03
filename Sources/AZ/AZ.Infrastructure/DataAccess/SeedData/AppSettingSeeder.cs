using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class AppSettingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting
                {
                    Id = 1,
                    Key = "SiteName",
                    Value = "Real Estate News",
                    Description = "Tên của website"
                },
                new AppSetting
                {
                    Id = 2,
                    Key = "DefaultLanguage",
                    Value = "en",
                    Description = "Ngôn ngữ mặc định của website"
                },
                new AppSetting
                {
                    Id = 3,
                    Key = "EnableCaching",
                    Value = "true",
                    Description = "Kích hoạt bộ nhớ cache"
                }
            );
        }
    }
}
