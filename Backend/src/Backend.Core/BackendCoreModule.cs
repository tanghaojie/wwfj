using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.JTCore;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Backend.Configuration;
using Backend.Localization;
using Backend.RunTime;
using System;

namespace Backend
{
    [DependsOn(typeof(AbpJTCoreModule))]
    public class BackendCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.MultiTenancy.IsEnabled = false;
            //Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            Configuration.Auditing.IsEnabled = false;
            Configuration.Localization.IsEnabled = false;
            Configuration.Authorization.IsEnabled = true;

            BackendLocalizationConfigurer.Configure(Configuration.Localization);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = DateTime.Now;
        }
    }
}