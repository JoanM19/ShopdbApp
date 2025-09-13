
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;

namespace PlatformShop.Domain.Repositories
{
    public interface ISuppliersRepository
    {
        Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync();
        Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id);
        Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model);
        Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model);
        Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id);

    }
}
