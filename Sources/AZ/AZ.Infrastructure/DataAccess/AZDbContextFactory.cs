using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess
{
    public class AZDbContextFactory : IDesignTimeDbContextFactory<AZDbContext>
    {
        public AZDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine("Start");
            // Load cấu hình
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var appSettingsConnectString = new AppSettingsConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(appSettingsConnectString);
            Console.WriteLine("Start 1" + appSettingsConnectString.Connection);
            var optionsBuilder = new DbContextOptionsBuilder<AZDbContext>();
            optionsBuilder.UseSqlServer(appSettingsConnectString.Connection);

            return new AZDbContext(optionsBuilder.Options);
        }
    }
}
