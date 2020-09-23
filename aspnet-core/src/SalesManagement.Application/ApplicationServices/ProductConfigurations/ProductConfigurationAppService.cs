using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.ProductConfigurations.Dto;
using SalesManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.ProductConfigurations
{
    public class ProductConfigurationAppService : SalesManagementAppServiceBase
    {
        public async Task Save(ProductConfigurationRequest input)
        {
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<ProductConfiguration>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại config");
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<ProductConfiguration>(input);
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<ProductConfiguration>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại config");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<ProductConfiguration> GetById(long id) => await WorkScope.GetAll<ProductConfiguration>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<ProductConfiguration>> GetProductConfigurations(int count = 10)
        {
            return await WorkScope.GetAll<ProductConfiguration>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
