using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JTCore.EntityFrameworkCore
{
    [DependsOn(typeof(AbpJTCoreModule), typeof(AbpEntityFrameworkCoreModule))]
    public class AbpJTCoreEntityFrameworkCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
           
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpJTCoreEntityFrameworkCoreModule).GetAssembly());
        }
    }
}
