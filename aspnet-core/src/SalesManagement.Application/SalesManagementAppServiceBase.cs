using Abp.Application.Services;
using Abp.Dependency;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using SalesManagement.Authorization.Users;
using SalesManagement.Ioc;
using SalesManagement.MultiTenancy;
using System;
using System.Threading.Tasks;

namespace SalesManagement
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SalesManagementAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }
        protected IWorkScope WorkScope { get; set; }
        public UserManager UserManager { get; set; }

        protected SalesManagementAppServiceBase()
        {
            LocalizationSourceName = SalesManagementConsts.LocalizationSourceName;
            WorkScope = IocManager.Instance.Resolve<IWorkScope>();
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
