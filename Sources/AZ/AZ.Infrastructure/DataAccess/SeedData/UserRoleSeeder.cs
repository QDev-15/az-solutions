using AZ.Core.Enums;
using AZ.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class UserRoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var userSys = new User()
            {
                Id = 1,
                Username = "sysadmin",
                Email = "nguyenquynhvp.ictu@gmail.com",
                PhoneNumber = "0988632841",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = UserStatus.Active
            };
            // Hash password
            var hasher = new PasswordHasher<User>();
            userSys.PasswordHash = hasher.HashPassword(userSys, "Admin@123");

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "System", Description = "System Role", RoleType = "System" },
                new Role { Id = 2, Name = "Admin", Description = "Admin Role", RoleType = "Admin" },
                new Role { Id = 3, Name = "User", Description = "User Role", RoleType = "User" }
            );

            modelBuilder.Entity<User>().HasData(userSys);
            modelBuilder.Entity<UserRole>().HasData(new UserRole() { Id = 1, RoleId = 1, UserId = 1 });
        }
    }
}
