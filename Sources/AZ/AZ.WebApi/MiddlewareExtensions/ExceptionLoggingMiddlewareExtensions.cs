using AZ.WebApi.Middlewares;

namespace AZ.WebApi.MiddlewareExtensions
{
    public static class ExceptionLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionLoggingMiddleware>();
        }
    }
}
