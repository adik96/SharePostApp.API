using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharePostApp.Core.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace SharePostApp.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate request, ILogger<ExceptionsMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception is UnauthorizedAccessException)
            {
                errorCode = nameof(HttpStatusCode.Unauthorized);
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exception is MainException blogException)
            {
                statusCode = blogException.ErrorCode.StatusCode;
                errorCode = blogException.ErrorCode.Message;
                message = string.IsNullOrEmpty(blogException.Message) ? errorCode : blogException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCode, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
}
