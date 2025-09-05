

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;

namespace PlatformShop.Domain.Repositories
{
    interface IShippersRepository
    {
        Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync();
        Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id);
        Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model);
        Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model);
        Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id);
    }
}
