using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;

namespace Chap05_03.Middleware
{
    /// <summary>
    /// Reference: https://github.com/JustinJohnWilliams/RequestLogging
    /// </summary>
    public class FlixOneLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FlixOneLoggerMiddleware> _logger;

        public FlixOneLoggerMiddleware(RequestDelegate next, ILogger<FlixOneLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation(await GetFormatedRequest(httpContext.Request));

            var originalBodyStream = httpContext.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                httpContext.Response.Body = responseBody;

                await _next(httpContext);

                _logger.LogInformation(await GetFormatedResponse(httpContext.Response));
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> GetFormatedRequest(HttpRequest httpRequest)
        {
            var body = httpRequest.Body;
            httpRequest.EnableRewind();

            var buffer = new byte[Convert.ToInt32(httpRequest.ContentLength)];
            await httpRequest.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            httpRequest.Body = body;

            return $"Log Request from middleware: {httpRequest.Scheme} {httpRequest.Host}{httpRequest.Path} {httpRequest.QueryString} {bodyAsText}";
        }

        private async Task<string> GetFormatedResponse(HttpResponse httpResponse)
        {
            httpResponse.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(httpResponse.Body).ReadToEndAsync();
            httpResponse.Body.Seek(0, SeekOrigin.Begin);

            return $"Log Response from middleware: {text}";
        }
    }
}