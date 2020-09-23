using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SalesManagement.Configuration;
using SalesManagement.Web;

namespace SalesManagement.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SalesManagementDbContextFactory : IDesignTimeDbContextFactory<SalesManagementDbContext>
    {
        public SalesManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SalesManagementDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SalesManagementDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SalesManagementConsts.ConnectionStringName));

            return new SalesManagementDbContext(builder.Options);
        }
    }
}
