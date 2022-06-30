using Newtonsoft.Json;
using System.Net;

namespace AtakDomain.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case KeyNotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = exception.Message }));
        }
    }
}