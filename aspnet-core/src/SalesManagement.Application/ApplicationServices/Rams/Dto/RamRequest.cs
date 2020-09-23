using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.Rams.Dto
{
    [AutoMap(typeof(Ram))]
    public class RamRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Storage { get; set; }
        public string Generation { get; set; }
        public string Bus { get; set; }
        public string Timing { get; set; }
        public string Voltage { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
