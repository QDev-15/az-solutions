using AZ.Core.Enums;
using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess.SeedData
{
    public static class RoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "System", Description = "System Role", RoleType = RoleType.System },
                new Role { Id = 2, Name = "Admin", Description = "Admin Role", RoleType = RoleType.Admin },
                new Role { Id = 3, Name = "User", Description = "User Role", RoleType = RoleType.User }
            );
        }
    }
}
