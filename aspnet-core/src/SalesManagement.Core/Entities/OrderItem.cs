using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Entities
{
    public class OrderItem : FullAuditedEntity<long>
    {
        public long Amount { get; set; }
        public long Price { get; set; }
        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }
        [ForeignKey(nameof(Product))]
        public long? ProductId { get; set; }
        [ForeignKey(nameof(Ram))]
        public long? RamId { get; set; }
        [ForeignKey(nameof(Case))]
        public long? CaseId { get; set; }
        [ForeignKey(nameof(VideoGraphicsArray))]
        public long? VideoGraphicsArrayId { get; set; }
        [ForeignKey(nameof(CpuId))]
        public long? CpuId { get; set; }
        [ForeignKey(nameof(MainBroad))]
        public long? MainBroadId { get; set; }
        [ForeignKey(nameof(SolidStateDrive))]
        public long? SolidStateDriveId { get; set; }
        [ForeignKey(nameof(HardDiskDrive))]
        public long? HardDiskDriveId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual Case Case { get; set; }
        public virtual VideoGraphicsArray VideoGraphicsArray { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual MainBroad MainBroad { get; set; }
        public virtual SolidStateDrive SolidStateDrive { get; set; }
        public virtual HardDiskDrive HardDiskDrive { get; set; }
    }
}
