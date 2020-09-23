using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.MainBroads.Dto;
using SalesManagement.Entities;
using SalesManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.MainBroads
{
    public class MainBroadAppService : SalesManagementAppServiceBase
    {
        private const string RootFolder = "wwwroot";
        private const string UploadFolder = "upload";
        private const string MainBroadFolder = "main-broad";
        public async Task Save([FromForm] MainBroadRequest input)
        {
            string fileLocation = UploadFile.CreateFolderIfNotExists(RootFolder, $@"{UploadFolder}\{MainBroadFolder}");
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<MainBroad>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại mainbroad");

                if (input.Images?.Count > 0)
                {
                    var images = input.ImagePaths ?? new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{MainBroadFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<MainBroad>(input);
                if (input.Images?.Count > 0)
                {
                    var images = new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{MainBroadFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<MainBroad>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại MainBroad");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<MainBroad> GetById(long id) => await WorkScope.GetAll<MainBroad>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<MainBroad>> GetMainBroads(int count = 10)
        {
            return await WorkScope.GetAll<MainBroad>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
