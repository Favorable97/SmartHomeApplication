namespace SmartHome.Application.Middleware
{
    public static class ExtensionsMiddleware
    {
        public static IApplicationBuilder ErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
