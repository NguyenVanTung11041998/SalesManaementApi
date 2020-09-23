using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.HardDiskDrives.Dto
{
    [AutoMap(typeof(HardDiskDrive))]
    public class HardDiskDriveRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Storage { get; set; }
        public string Size { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Gurantee { get; set; }
        public long Total { get; set; }
    }
}
