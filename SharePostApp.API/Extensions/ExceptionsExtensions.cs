using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharePostApp.Core.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SharePostApp.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace SharePostApp.API.Extensions
{
    public static class ExceptionsExtensions
    {
        public static void UseMainExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
