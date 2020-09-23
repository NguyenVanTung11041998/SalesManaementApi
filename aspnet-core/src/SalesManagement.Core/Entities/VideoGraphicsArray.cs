using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class VideoGraphicsArray : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string TradeMark { get; set; }
        public string Chip { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string GpuClock { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Gurantee { get; set; }
        public long Total { get; set; }
    }
}
