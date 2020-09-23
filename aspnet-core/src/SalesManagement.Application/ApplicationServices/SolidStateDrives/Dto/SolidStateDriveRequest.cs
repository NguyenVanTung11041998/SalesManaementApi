using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.SolidStateDrives.Dto
{
    [AutoMap(typeof(SolidStateDrive))]
    public class SolidStateDriveRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Size { get; set; }
        public string Connect { get; set; }
        public string Nand { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Gurantee { get; set; }
        public long Total { get; set; }
    }
}
