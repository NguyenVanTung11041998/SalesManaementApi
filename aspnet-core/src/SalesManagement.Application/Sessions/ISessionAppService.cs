using System.Threading.Tasks;
using Abp.Application.Services;
using SalesManagement.Sessions.Dto;

namespace SalesManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
