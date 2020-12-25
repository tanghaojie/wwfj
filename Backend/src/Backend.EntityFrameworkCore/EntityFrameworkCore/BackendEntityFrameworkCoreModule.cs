using Abp.Configuration.Startup;
using Abp.EntityFrameworkCore;
using Abp.JTCore.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Backend.Configuration;

namespace Backend.EntityFrameworkCore
{
    [DependsOn(
        typeof(BackendCoreModule), 
        typeof(AbpJTCoreEntityFrameworkCoreModule))]
    public class BackendEntityFrameworkCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendEntityFrameworkCoreModule).GetAssembly());
        }
    }
}