using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.Cpus.Dto
{
    [AutoMap(typeof(Cpu))]
    public class CpuRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string CpuInfor { get; set; }
        public string Socket { get; set; }
        public string Core { get; set; }
        public string Cache { get; set; }
        public string Tdp { get; set; }
        public string Description { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
