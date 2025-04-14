using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Providers;
using AZ.Infrastructure.Repositories;
using AZ.Infrastructure.Services;
using AZ.WebApi.MiddlewareExtensions;
using AZ.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using AZ.Infrastructure;
using AZ.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using AZ.Infrastructure.Entities;

var builder = WebApplication.CreateBuilder(args);

// Load cấu hình theo môi trường tự động:
// - appsettings.json
// - appsettings.{ENVIRONMENT}.json (ví dụ: Development, Production)
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Bind config section vào class
var appSettingConnect = builder.Configuration
    .GetSection("ConnectionStrings")
    .Get<AppSettingsConnectionStrings>();
var appSettingJwt = builder.Configuration
    .GetSection("Jwt")
    .Get<AppSettingsJwt>();
    

// Đăng ký để dùng ở các nơi khác (inject được) bằng IOptions
builder.Services.Configure<AppSettingsConnectionStrings>(
    builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<AppSettingsJwt>(
    builder.Configuration.GetSection("Jwt"));
// inject trực tiếp AppSettingConnect (không cần IOptions)
builder.Services.AddSingleton(appSettingConnect);
builder.Services.AddSingleton(appSettingJwt);
// Init connection database
builder.Services.AddDbContext<AZDbContext>(options =>
    options.UseSqlServer(appSettingConnect.Connection));


// Add services to the container.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ITimeZoneProvider, TimeZoneProvider>();
builder.Services.AddScoped<IMappingProvider, MappingProvider>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// log services
builder.Services.AddSingleton<ILogQueueProvider, LogQueueProvider>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

// background services
builder.Services.AddHostedService<LogBackgroundService>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseGlobalExceptionLogger();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
