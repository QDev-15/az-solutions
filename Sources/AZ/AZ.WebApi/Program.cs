using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.Providers;
using AZ.Infrastructure.Providers;
using AZ.Infrastructure.Repositories;
using AZ.Infrastructure.Services;
using AZ.WebApi.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ITimeZoneProvider, TimeZoneProvider>();
builder.Services.AddScoped<IMappingProvider, MappingProvider>();

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
