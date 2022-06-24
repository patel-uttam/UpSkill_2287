using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace UpSkillFoundationApi
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<FirstMiddleware> logger;


        public FirstMiddleware(RequestDelegate next , ILogger<FirstMiddleware> _logger)
        {
            _next = next;
            logger = _logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == 401)
            {
                var originalBodyData = httpContext.Response.Body;

                await using(MemoryStream memory = new MemoryStream())
                {
                    httpContext.Response.Body = memory;

                    await _next(httpContext);

                    memory.Seek(0, SeekOrigin.Begin);
                    var ReadBodyResponse =  new StreamReader(memory).ReadToEnd();
                    memory.Seek(0, SeekOrigin.Begin);

                    logger.LogWarning(ReadBodyResponse);

                    memory.CopyTo(originalBodyData);

                    httpContext.Response.Body = originalBodyData;
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirstMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}
