using System.Text.Json;

namespace SmartHome.Application.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        private RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }
        private static async Task HandleError(HttpContext context, Exception exception)
        {
            var response = ApiResponse<object>.Error($"Произошла ошибка! {exception.Message}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            await JsonSerializer.SerializeAsync(context.Response.Body, response);
        }
    }
}
