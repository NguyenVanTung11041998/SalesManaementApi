using Abp.Domain.Entities.Auditing;

namespace SalesManagement.Entities
{
    public class Case : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string MainBroad { get; set; }
        public string Description { get; set; }
        public string ImageString { get; set; }
        public long Price { get; set; }
        public long Total { get; set; }
    }
}
