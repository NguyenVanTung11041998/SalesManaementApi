using System.Threading.Tasks;
using SalesManagement.Configuration.Dto;

namespace SalesManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
