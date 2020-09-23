using Abp.Authorization;
using SalesManagement.Authorization.Roles;
using SalesManagement.Authorization.Users;

namespace SalesManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
