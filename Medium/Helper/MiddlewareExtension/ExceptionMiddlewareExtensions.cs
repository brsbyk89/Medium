using Microsoft.AspNetCore.Builder;

namespace Medium.Helper.MiddlewareExtension
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddeware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
