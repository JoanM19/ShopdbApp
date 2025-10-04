

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Order;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Persistence.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        public Task<OperationResult<OrderCreateModel>> CreateOrderAsync(OrderCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderDeleteModel>> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<OrderGetModel>>> GetAllOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderGetModel>> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderUpdateModel>> UpdateOrderAsync(int id, OrderUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
