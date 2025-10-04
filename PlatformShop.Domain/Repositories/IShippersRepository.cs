

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;

namespace PlatformShop.Domain.Repositories
{
    public interface IShippersRepository
    {
        Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model);
        Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id, ShippersDeleteModel shippersDelete);
        Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync();
        Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id);
        Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model);
    }
        
}
