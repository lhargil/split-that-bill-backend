using System;
using Microsoft.AspNetCore.Builder;
using SplitThatBill.Backend.API.Middlewares;

namespace SplitThatBill.Backend.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestContextDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestContextDataMiddleware>();
        }
    }
}
