using AZ.Infrastructure.DataAccess.Configurations;
using AZ.Infrastructure.DataAccess.SeedData;
using AZ.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.DataAccess
{
    public class AZDbContext : DbContext
    {
        public AZDbContext(DbContextOptions<AZDbContext> options) : base(options) { }

        // Các bảng trong cơ sở dữ liệu
        public DbSet<Advertisement> Advertisements { set; get; }
        public DbSet<Article> Articles { set; get; }
        public  DbSet<ArticleTranslation> ArticleTranslations { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<CategoryPermission> CategoryPermissions { set; get; }
        public DbSet<CategoryTranslation> CategoryTranslations { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Log> Logs { set; get; }
        public DbSet<Media> Medias { set; get; }
        public DbSet<Rating> Ratings { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<AppSetting> AppSettings { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<TrafficStatistic> TrafficStatistics { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<UserRole> UserRoles { set; get; }
        public DbSet<Language> Languages { get; set; }

        // Hàm OnModelCreating để cấu hình mối quan hệ giữa các bảng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tạo cấu hình cho các bảng và các mối quan hệ giữa chúng
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppSettingConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TrafficStatisticConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            AppSettingSeeder.Seed(modelBuilder);
            LanguageSeeder.Seed(modelBuilder);
        }
    }
}
