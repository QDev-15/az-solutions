using AZ.Core.Enums;
using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var userSys = new User()
            {
                Username = "sysadmin",
                Email = "nguyenquynhvp.ictu@gmail.com",
                PhoneNumber = "0988632841",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = UserStatus.Active
            };
            modelBuilder.Entity<User>().HasData(
               
            );
        }
    }
}
