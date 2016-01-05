using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Mvc;

namespace HotelsWizard.Connector {
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class RestExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RestExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) {
            _next = next;
            _logger = loggerFactory.CreateLogger<RestExceptionHandlerMiddleware>();

        }

        public async Task Invoke(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch (Exception ex) {
                _logger.LogError("An unhandled exception has occurred: " + ex.Message, ex);
                // We can't do anything if the response has already started, just abort. 
                if (httpContext.Response.HasStarted) {
                    _logger.LogWarning("The response has already started, the error handler will not be executed.");
                    throw;
                }

                if (ex is RestException) {
                    var error = ((RestException)ex).Error;
                    var result = new JsonResult(error);
                    var meta = error.Meta;
                    httpContext.Response.Clear();
                    httpContext.Response.StatusCode = meta.StatusCode;
                    await httpContext.Response.WriteAsync("Hello World!!");
//                    httpContext.Response.
                }
                //                httpContext.Response.
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<RestExceptionHandlerMiddleware>();
        }
    }
}
