using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Middleware.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(err => {
                err.Run(async context => {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        int statusCode = (int)HttpStatusCode.InternalServerError;
                        string message = contextFeature.Error.Message;
                        
                        context.Response.StatusCode = statusCode;

                        var response = new {
                            StatusCode = statusCode,
                            Message = message
                        };
                        var result = JsonSerializer.Serialize(response);
                        await context.Response.WriteAsync(result);
                    }
                });
            });
        }
    }
}