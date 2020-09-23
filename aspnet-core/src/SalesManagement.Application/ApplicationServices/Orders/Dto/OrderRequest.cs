using Abp.AutoMapper;
using SalesManagement.Entities;
using System.Collections.Generic;

namespace SalesManagement.ApplicationServices.Orders.Dto
{
    [AutoMap(typeof(Order))]
    public class OrderRequest
    {
        public string PlaceOrder { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemRequest> OrderItemRequests { get; set; }
    }
}
