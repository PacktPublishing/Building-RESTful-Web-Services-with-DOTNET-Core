using Microsoft.AspNetCore.Builder;

namespace Chap05_03.Middleware
{
    public static class FlixOneStoreLoggerExtension
    {
        public static IApplicationBuilder UseFlixOneLoggerMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<FlixOneLoggerMiddleware>();
        }
    }
}