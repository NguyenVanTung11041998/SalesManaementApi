using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagement.ApplicationServices.Products.Dto
{
    [AutoMap(typeof(Product))]
    public class ProductRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Graphic { get; set; }
        public string Storage { get; set; }
        public string Pin { get; set; }
        public string Mass { get; set; }
        public string Operating { get; set; }
        public string ImageString { get; set; }
        public long Total { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
        public ProductType ProductType { get; set; }
        public long? ProductConfigurationId { get; set; }
    }
}
