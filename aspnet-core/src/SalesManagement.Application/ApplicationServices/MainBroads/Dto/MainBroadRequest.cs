using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.MainBroads.Dto
{
    [AutoMap(typeof(MainBroad))]
    public class MainBroadRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Socket { get; set; }
        public string Ram { get; set; }
        public string SupRam { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
