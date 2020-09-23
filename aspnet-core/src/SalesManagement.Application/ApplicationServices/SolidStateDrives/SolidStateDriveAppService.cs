using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.SolidStateDrives.Dto;
using SalesManagement.Entities;
using SalesManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.SolidStateDrives
{
    public class SolidStateDriveAppService : SalesManagementAppServiceBase
    {
        private const string RootFolder = "wwwroot";
        private const string UploadFolder = "upload";
        private const string SolidStateDriveFolder = "solid-state-drive";
        public async Task Save([FromForm] SolidStateDriveRequest input)
        {
            string fileLocation = UploadFile.CreateFolderIfNotExists(RootFolder, $@"{UploadFolder}\{SolidStateDriveFolder}");
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<SolidStateDrive>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại ssd");

                if (input.Images?.Count > 0)
                {
                    var images = input.ImagePaths ?? new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{SolidStateDriveFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<SolidStateDrive>(input);
                if (input.Images?.Count > 0)
                {
                    var images = new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{SolidStateDriveFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<SolidStateDrive>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại ssd");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<SolidStateDrive> GetById(long id) => await WorkScope.GetAll<SolidStateDrive>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<SolidStateDrive>> GetSolidStateDrives(int count = 10)
        {
            return await WorkScope.GetAll<SolidStateDrive>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
