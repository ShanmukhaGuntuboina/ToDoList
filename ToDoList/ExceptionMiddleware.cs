using Serilog;
using System.Net;

namespace ToDoList
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {   
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                Log.Fatal(ex, "Application encountered a fatal error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("An unexpected error occurred.");

        }
    }
}
