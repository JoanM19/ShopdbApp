using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.OrderDetails;

namespace PlatformShop.Domain.Repositories
{
    public interface IOrderDetailsRepository
    {
        Task<OperationResult<List<OrderDetailsModel>>> GetAllOrderDetailsAsync();
        Task<OperationResult<OrderDetailsModel>> GetOrderDetailsByIdAsync(int id);
        Task<OperationResult<OrderDetailsCreateModel>> CreateOrderDetailsAsync(OrderDetailsCreateModel model);
        Task<OperationResult<OrderDetailsUpdateModel>> UpdateOrderDetailsAsync(int id, OrderDetailsUpdateModel model);
        Task<OperationResult<OrderDetailsDeleteModel>> DeleteOrderDetailsAsync(int id);


    }
}
