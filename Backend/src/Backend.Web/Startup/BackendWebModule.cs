using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Backend.Configuration;
using Backend.EntityFrameworkCore;
using Backend.Web.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace Backend.Web.Startup
{
    [DependsOn(
        typeof(BackendApplicationModule),
        typeof(BackendEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule),
        typeof(BackendWebHostModule)
        )]
    public class BackendWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BackendWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(BackendConsts.ConnectionStringName);
            //Configuration.Navigation.Providers.Add<BackendNavigationProvider>();
            //Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(BackendApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BackendWebModule).Assembly);
        }
    }
}