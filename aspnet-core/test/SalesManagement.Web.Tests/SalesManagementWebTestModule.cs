using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SalesManagement.EntityFrameworkCore;
using SalesManagement.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SalesManagement.Web.Tests
{
    [DependsOn(
        typeof(SalesManagementWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SalesManagementWebTestModule : AbpModule
    {
        public SalesManagementWebTestModule(SalesManagementEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SalesManagementWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SalesManagementWebMvcModule).Assembly);
        }
    }
}