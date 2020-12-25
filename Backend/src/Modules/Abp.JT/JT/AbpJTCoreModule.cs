using Abp.JT;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JTCore
{
    [DependsOn(typeof(AbpJTCommonModule))]
    public class AbpJTCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
           
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpJTCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
          
        }

    }
}
