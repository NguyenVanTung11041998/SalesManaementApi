using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SalesManagement.Configuration;

namespace SalesManagement.Web.Host.Startup
{
    [DependsOn(
       typeof(SalesManagementWebCoreModule))]
    public class SalesManagementWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SalesManagementWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SalesManagementWebHostModule).GetAssembly());
        }
    }
}
