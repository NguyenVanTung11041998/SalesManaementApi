using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.Cases.Dto
{
    [AutoMap(typeof(Case))]
    public class CaseRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string MainBroad { get; set; }
        public string Description { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
