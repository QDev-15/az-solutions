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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

// log services
builder.Services.AddSingleton<ILogQueueProvider, LogQueueProvider>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
// background services
builder.Services.AddHostedService<LogBackgroundService>();

builder.Services.AddHttpContextAccessor();
// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = appSettingJwt.Issuer,
        ValidAudience = appSettingJwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingJwt.Key)),
        ClockSkew = TimeSpan.Zero
    };
    // Thêm sự kiện kiểm tra trong DB sau khi token được giải mã
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var userSessionRepo = context.HttpContext.RequestServices.GetRequiredService<IUserSessionRepository>();
            
            var jti = context.Principal?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            if (string.IsNullOrEmpty(jti) || userSessionRepo == null)
            {
                context.Fail("Token không hợp lệ.");
                return;
            }

            var session = await userSessionRepo.GetByJtiAsync(jti);
            if (session == null || !session.IsActive)
            {
                context.Fail("Token đã bị thu hồi hoặc không còn hợp lệ.");
            }
        }
    };
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true; // Đẹp hơn để debug
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AZ API", Version = "v1" });

    // ✅ Add JWT Auth to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Nhập token dạng: Bearer {your JWT token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AZDbContext>();
    dbContext.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseRouting();
app.UseGlobalExceptionLogger();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
