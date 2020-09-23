using SalesManagement.ApplicationServices.Orders.Dto;
using SalesManagement.Entities;
using System.Threading.Tasks;

namespace SalesManagement.ApplicationServices.Orders
{
    public class OrderAppService : SalesManagementAppServiceBase
    {
        public async Task CreateOrder(OrderRequest input)
        {
            var order = ObjectMapper.Map<Order>(input);
            long id = await WorkScope.InsertAndGetIdAsync(order);
            foreach (var item in input.OrderItemRequests)
            {
                var orderItem = ObjectMapper.Map<OrderItem>(item);
                orderItem.OrderId = id;
                await WorkScope.InsertAsync(orderItem);
            }
        }
    }
}
