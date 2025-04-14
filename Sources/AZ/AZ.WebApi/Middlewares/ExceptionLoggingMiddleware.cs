using AZ.Infrastructure.Interfaces;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Extentions;

namespace AZ.WebApi.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, ILogQueueProvider logQueue)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var stackTrace = ex.StackTrace;
                var source = context.Request.Path;

                // Đẩy log lỗi vào hàng đợi
                logQueue.LogError(message, source, stackTrace);

                // Ghi log lỗi vào hệ thống mặc định nếu muốn
                _logger.LogError(ex, "Unhandled Exception");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Có lỗi xảy ra. Vui lòng thử lại sau.",
                    detail = ex.Message // Có thể ẩn nếu là production
                });
            }
        }
    }

}
