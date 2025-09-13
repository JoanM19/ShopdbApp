

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Persistence.Repositories.Shippers
{
    public class ShippersRepository : IShippersRepository
    {
        public Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
