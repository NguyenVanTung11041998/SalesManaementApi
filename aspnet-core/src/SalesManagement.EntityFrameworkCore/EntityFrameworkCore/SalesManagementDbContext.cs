using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Authorization.Roles;
using SalesManagement.Authorization.Users;
using SalesManagement.Entities;
using SalesManagement.MultiTenancy;

namespace SalesManagement.EntityFrameworkCore
{
    public class SalesManagementDbContext : AbpZeroDbContext<Tenant, Role, User, SalesManagementDbContext>
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<HardDiskDrive> HardDiskDrives { get; set; }
        public DbSet<MainBroad> MainBroads { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductConfiguration> ProductConfigurations { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<SolidStateDrive> SolidStateDrives { get; set; }
        public DbSet<VideoGraphicsArray> VideoGraphicsArrays { get; set; }

        public SalesManagementDbContext(DbContextOptions<SalesManagementDbContext> options)
            : base(options)
        {
        }
    }
}
