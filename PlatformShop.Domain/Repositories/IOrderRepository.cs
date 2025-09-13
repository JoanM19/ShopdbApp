using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Order;

namespace PlatformShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<OperationResult<List<OrderGetModel>>> GetAllOrderAsync();
        Task<OperationResult<OrderGetModel>> GetOrderByIdAsync(int id);
        Task<OperationResult<OrderCreateModel>> CreateOrderAsync(OrderCreateModel model);
        Task<OperationResult<OrderUpdateModel>> UpdateOrderAsync(int id, OrderUpdateModel model);
        Task<OperationResult<OrderDeleteModel>> DeleteOrderAsync(int id);
    }
}
