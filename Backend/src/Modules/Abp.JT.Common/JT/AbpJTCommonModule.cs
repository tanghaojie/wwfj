using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;
using Abp.JT.Common.Tenant;
using Abp.Reflection.Extensions;

namespace Abp.JT
{
    public class AbpJTCommonModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            ReplaceTenantStore();
            IocManager.RegisterAssemblyByConvention(typeof(AbpJTCommonModule).GetAssembly());
        }

        public override void PostInitialize()
        {
        }

        private void ReplaceTenantStore()
        {
            if (Configuration.MultiTenancy.IsEnabled)
            {
                IocManager.Register<ITenantStore, TenantStore>(DependencyLifeStyle.Transient);
            }
            else
            {
                IocManager.Register<ITenantStore, NoneTenantStore>(DependencyLifeStyle.Singleton);
            }
        }
    }
}
