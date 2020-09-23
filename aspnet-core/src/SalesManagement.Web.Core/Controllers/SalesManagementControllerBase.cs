using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SalesManagement.Controllers
{
    public abstract class SalesManagementControllerBase: AbpController
    {
        protected SalesManagementControllerBase()
        {
            LocalizationSourceName = SalesManagementConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
