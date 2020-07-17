using Abp.Modules;
using Abp.Reflection.Extensions;
using Backend.Localization;

namespace Backend
{
    public class BackendCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            Configuration.Auditing.IsEnabled = false;
            Configuration.Localization.IsEnabled = false;
            Configuration.Authorization.IsEnabled = true;
            Configuration.MultiTenancy.IsEnabled = false;

            BackendLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendCoreModule).GetAssembly());
        }
    }
}