using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Web.Startup
{
    public class CorsConfigurer
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy("policy", builder =>
                {
                    builder
                    //.AllowAnyOrigin()
                    //.WithOrigins(new string[] { "http://127.0.0.1:5500" })
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public static void Use(IApplicationBuilder app)
        {
            app.UseCors("policy");
        }
    }
}
