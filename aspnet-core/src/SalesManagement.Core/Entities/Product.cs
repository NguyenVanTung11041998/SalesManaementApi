using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Entities
{
    public class Product : FullAuditedEntity<long>
    {
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
        public ProductType ProductType { get; set; }
        [ForeignKey(nameof(ProductConfiguration))]
        public long? ProductConfigurationId { get; set; }
        public virtual ProductConfiguration ProductConfiguration { get; set; }
    }

    public enum ProductType : byte
    {
        Laptop = 0,
        PC = 1
    }
}
