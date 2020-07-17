using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Backend.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Web.Host
{
    [DependsOn(
   typeof(BackendApplicationModule))]
    public class BackendWebHostModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        //private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public BackendWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }
        public override void Initialize()
        {
            var thisAssembly = typeof(BackendWebHostModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => cfg.AddMaps(thisAssembly));
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(BackendConsts.ConnectionStringName);

            Configuration.Modules.AbpAspNetCore()
              .CreateControllersForAppServices(
                  typeof(BackendApplicationModule).GetAssembly()
              );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();


            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(7);

            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            //tokenAuthConfig.SecurityKey = symmetricSecurityKey;
            //tokenAuthConfig.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            //tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            //tokenAuthConfig.Expiration = TimeSpan.FromHours(double.Parse(_appConfiguration["Authentication:JwtBearer:ExpireHours"]));
        }
    }
}
