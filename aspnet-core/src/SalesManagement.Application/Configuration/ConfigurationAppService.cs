using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SalesManagement.Configuration.Dto;

namespace SalesManagement.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SalesManagementAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
