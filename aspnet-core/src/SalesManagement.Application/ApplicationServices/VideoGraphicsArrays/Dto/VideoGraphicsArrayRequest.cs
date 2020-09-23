using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.VideoGraphicsArrays.Dto
{
    [AutoMap(typeof(VideoGraphicsArray))]
    public class VideoGraphicsArrayRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string TradeMark { get; set; }
        public string Chip { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string GpuClock { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Gurantee { get; set; }
        public long Total { get; set; }
    }
}
