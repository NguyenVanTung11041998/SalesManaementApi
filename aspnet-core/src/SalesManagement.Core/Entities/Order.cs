using Abp.Domain.Entities.Auditing;
using System;

namespace SalesManagement.Entities
{
    public class Order : FullAuditedEntity<long>
    {
        public OrderStatus Status { get; set; }
        public DateTime RequiredDate { get; set; }
        public string PlaceOrder { get; set; }
        public DateTime? TranDate { get; set; }
        public string Description { get; set; }
        public long TotalPay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CustomerName { get; set; }
    }

    public enum OrderStatus
    {
        AwaitingApproval = 0,
        Cancel = 1,
        Confirmed = 2,
        AlreadyPaid = 3
    }
}
