using Microsoft.AspNetCore.Http.Extensions;

namespace Academia.Ejemplo.Middleware
{
    public class LoggerJuegoMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggerJuegoMiddleware> logger;

        public LoggerJuegoMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<LoggerJuegoMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            this.logger.LogInformation($"Method: {context.Request.Method}, URL: {context.Request.GetDisplayUrl()}");
            await next.Invoke(context);
            this.logger.LogInformation($"Status code: {context.Response.StatusCode}, Content-Type: {context.Response.ContentType}");
        }
    }
}
