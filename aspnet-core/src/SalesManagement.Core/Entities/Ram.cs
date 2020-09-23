using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class Ram : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Storage { get; set; }
        public string Generation { get; set; }
        public string Bus { get; set; }
        public string Timing { get; set; }
        public string Voltage { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
