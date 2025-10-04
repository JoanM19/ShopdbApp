

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.OrderDetails;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Persistence.Repositories.OrderDetails
{
    public class OrderDetailsRepositorys : IOrderDetailsRepository
    {
        public Task<OperationResult<OrderDetailsCreateModel>> CreateOrderDetailsAsync(OrderDetailsCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderDetailsDeleteModel>> DeleteOrderDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<OrderDetailsModel>>> GetAllOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderDetailsModel>> GetOrderDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<OrderDetailsUpdateModel>> UpdateOrderDetailsAsync(int id, OrderDetailsUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
