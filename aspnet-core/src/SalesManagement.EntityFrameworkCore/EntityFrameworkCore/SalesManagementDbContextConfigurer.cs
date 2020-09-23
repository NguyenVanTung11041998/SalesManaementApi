using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SalesManagement.EntityFrameworkCore
{
    public static class SalesManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SalesManagementDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SalesManagementDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
