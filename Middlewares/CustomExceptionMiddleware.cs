using System.Net;
using System.Text.Json;

namespace Middleware.Middlewares
{
    public class CustomExceptionMiddleware : IMiddleware
    {
        // private readonly RequestDelegate _next;

        // public CustomExceptionMiddleware(RequestDelegate next)
        // {
        //     _next = next;
        // }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = ex.Message;

                context.Response.StatusCode = statusCode;

                var response = new
                {
                    StatusCode = statusCode,
                    Message = message
                };
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
        }
    }
}