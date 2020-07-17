using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Web.Startup
{
    public class CookieConfigurer
    {
        public static void Configure(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "JT.Cookie";
                    options.ExpireTimeSpan = new TimeSpan(0, 15, 0);
                });
            
        }

        public static void Use(IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseCookiePolicy();
        }
    }
}
