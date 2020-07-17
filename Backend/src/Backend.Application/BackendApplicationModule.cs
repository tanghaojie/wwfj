using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Backend.JTAuthenticate;
using Castle.MicroKernel.Registration;

namespace Backend
{
    [DependsOn(
        typeof(BackendCoreModule),
        typeof(AbpAutoMapperModule))]
    public class BackendApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            JTAuthenticateInterceptorRegister.Initialize(handler);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BackendApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => cfg.AddMaps(thisAssembly));
        }
    }
}