using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class MainBroad : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Socket { get; set; }
        public string Ram { get; set; }
        public string SupRam { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
