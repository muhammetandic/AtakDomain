namespace AtakDomain.API.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}