
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;

namespace PlatformShop.Domain.Repositories
{
    public interface ISuppliersRepository
    {
        Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model);
        Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id, SuppliersDeleteModel suppliersDelete);
        Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync();
        Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id);
        Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model);
        

    }
}
