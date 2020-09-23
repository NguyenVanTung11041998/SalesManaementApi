using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.HardDiskDrives.Dto;
using SalesManagement.Entities;
using SalesManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.HardDiskDrives
{
    public class HardDiskDriveAppService : SalesManagementAppServiceBase
    {
        private const string RootFolder = "wwwroot";
        private const string UploadFolder = "upload";
        private const string HardDiskDriveFolder = "hard-disk-drive";
        public async Task Save([FromForm] HardDiskDriveRequest input)
        {
            string fileLocation = UploadFile.CreateFolderIfNotExists(RootFolder, $@"{UploadFolder}\{HardDiskDriveFolder}");
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<HardDiskDrive>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại hdd");

                if (input.Images?.Count > 0)
                {
                    var images = input.ImagePaths ?? new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{HardDiskDriveFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<HardDiskDrive>(input);
                if (input.Images?.Count > 0)
                {
                    var images = new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{HardDiskDriveFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<HardDiskDrive>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại hdd");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<HardDiskDrive> GetById(long id) => await WorkScope.GetAll<HardDiskDrive>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<HardDiskDrive>> GetHardDiskDrives(int count = 10)
        {
            return await WorkScope.GetAll<HardDiskDrive>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
