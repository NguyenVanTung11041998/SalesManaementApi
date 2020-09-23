using Abp.Application.Services;
using SalesManagement.MultiTenancy.Dto;

namespace SalesManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

