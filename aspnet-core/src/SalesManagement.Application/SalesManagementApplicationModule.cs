using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SalesManagement.Authorization;

namespace SalesManagement
{
    [DependsOn(
        typeof(SalesManagementCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SalesManagementApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SalesManagementAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SalesManagementApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
