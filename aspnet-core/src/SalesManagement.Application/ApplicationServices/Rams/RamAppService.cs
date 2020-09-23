using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.Rams.Dto;
using SalesManagement.Entities;
using SalesManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.Rams
{
    public class RamAppService : SalesManagementAppServiceBase
    {
        private const string RootFolder = "wwwroot";
        private const string UploadFolder = "upload";
        private const string RamFolder = "ram";
        public async Task Save([FromForm] RamRequest input)
        {
            string fileLocation = UploadFile.CreateFolderIfNotExists(RootFolder, $@"{UploadFolder}\{RamFolder}");
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<Ram>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại ram");

                if (input.Images?.Count > 0)
                {
                    var images = input.ImagePaths ?? new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{RamFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<Ram>(input);
                if (input.Images?.Count > 0)
                {
                    var images = new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{RamFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<Ram>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại ram");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<Ram> GetById(long id) => await WorkScope.GetAll<Ram>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Ram>> GetRams(int count = 10)
        {
            return await WorkScope.GetAll<Ram>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
