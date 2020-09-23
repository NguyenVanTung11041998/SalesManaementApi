using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class SolidStateDrive : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Size { get; set; }
        public string Connect { get; set; }
        public string Nand { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Gurantee { get; set; }
        public long Total { get; set; }
    }
}
