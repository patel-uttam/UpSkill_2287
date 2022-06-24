using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace UpSkillFoundationApi.CustomException
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalException
    {
        private readonly RequestDelegate _next;

        public GlobalException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<GlobalException> _logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                await HandleExceptionMessageAsync(httpContext, e,_logger);
            }
        }

        // exception method
        private static Task HandleExceptionMessageAsync(HttpContext context, Exception e , ILogger<GlobalException> logger)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var exception = JsonConvert.SerializeObject(new
            {
                errorMessage = e.Message,
                statusCode = StatusCodes.Status500InternalServerError,
                link = context.Request.Path
            });
            logger.LogError(exception.ToString());
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(exception);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalException>();
        }
    }

}
 