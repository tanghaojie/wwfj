﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Web.Startup
{
    public static class JwtTokenMiddleware
    {
        public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder app, string schema = JwtBearerDefaults.AuthenticationScheme)
        {
            return app.Use(async (ctx, next) =>
            {
                if (ctx.User.Identity?.IsAuthenticated != true)
                {
                    var result = await ctx.AuthenticateAsync(schema);
                    if (result.Succeeded && result.Principal != null)
                    {
                        ctx.User = result.Principal;
                    }
                }

                await next();
            });
        }
    }
}
