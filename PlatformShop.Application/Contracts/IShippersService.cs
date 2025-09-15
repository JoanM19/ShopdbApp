
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;

namespace PlatformShop.Application.Contracts
{
    public interface IShippersService
    {
        Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model);
        Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id, ShippersDeleteModel shippersDelete);
        Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id);
        Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync();
        Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model);
        
    }
}
