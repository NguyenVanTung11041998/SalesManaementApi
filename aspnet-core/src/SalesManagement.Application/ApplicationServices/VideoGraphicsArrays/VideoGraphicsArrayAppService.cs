using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ApplicationServices.VideoGraphicsArrays.Dto;
using SalesManagement.Entities;
using SalesManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.VideoGraphicsArrays
{
    public class VideoGraphicsArrayAppService : SalesManagementAppServiceBase
    {
        private const string RootFolder = "wwwroot";
        private const string UploadFolder = "upload";
        private const string VideoGraphicsArrayFolder = "video-graphics-array";
        public async Task Save([FromForm] VideoGraphicsArrayRequest input)
        {
            string fileLocation = UploadFile.CreateFolderIfNotExists(RootFolder, $@"{UploadFolder}\{VideoGraphicsArrayFolder}");
            if (input.Id.HasValue)
            {
                var data = await WorkScope.GetAll<VideoGraphicsArray>().FirstOrDefaultAsync(x => x.Id == input.Id);
                if (data == null)
                    throw new UserFriendlyException("Không tồn tại vga");

                if (input.Images?.Count > 0)
                {
                    var images = input.ImagePaths ?? new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{VideoGraphicsArrayFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                ObjectMapper.Map(input, data);
            }
            else
            {
                var data = ObjectMapper.Map<VideoGraphicsArray>(input);
                if (input.Images?.Count > 0)
                {
                    var images = new List<string>();
                    foreach (var item in input.Images)
                    {
                        string fileName = await UploadFile.UploadAsync(fileLocation, item);
                        images.Add($@"{UploadFolder}\{VideoGraphicsArrayFolder}\{fileName}");
                    }
                    data.ImageString = string.Join("-", images);
                }
                await WorkScope.InsertAsync(data);
            }
        }

        public async Task Delete(long id)
        {
            var data = await WorkScope.GetAll<VideoGraphicsArray>().FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                throw new UserFriendlyException("Không tồn tại vga");

            await WorkScope.DeleteAsync(data);
        }

        public async Task<VideoGraphicsArray> GetById(long id) => await WorkScope.GetAll<VideoGraphicsArray>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<VideoGraphicsArray>> GetVideoGraphicsArrays(int count = 10)
        {
            return await WorkScope.GetAll<VideoGraphicsArray>()
                            .OrderByDescending(x => x.CreationTime)
                            .Take(count)
                            .ToListAsync();
        }
    }
}
