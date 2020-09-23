using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class Cpu : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string CpuInfor { get; set; }
        public string Socket { get; set; }
        public string Core { get; set; }
        public string Cache { get; set; }
        public string Tdp { get; set; }
        public string Description { get; set; }
        public string ImageString { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
