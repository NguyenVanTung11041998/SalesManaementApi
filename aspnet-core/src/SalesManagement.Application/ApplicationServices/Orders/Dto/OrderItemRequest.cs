using Abp.AutoMapper;
using SalesManagement.Entities;

namespace SalesManagement.ApplicationServices.Orders.Dto
{
    [AutoMap(typeof(OrderItem))]
    public class OrderItemRequest
    {
        public long Amount { get; set; }
        public long Price { get; set; }
        public long? ProductId { get; set; }
        public long? RamId { get; set; }
        public long? CaseId { get; set; }
        public long? VideoGraphicsArrayId { get; set; }
        public long? CpuId { get; set; }
        public long? MainBroadId { get; set; }
        public long? SolidStateDriveId { get; set; }
        public long? HardDiskDriveId { get; set; }
    }
}
