using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Backend.EntityFrameworkCore
{
    [DependsOn(
        typeof(BackendCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class BackendEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendEntityFrameworkCoreModule).GetAssembly());
        }
    }
}