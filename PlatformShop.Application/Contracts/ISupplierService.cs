

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;

namespace PlatformShop.Application.Contracts
{
    public interface ISupplierService
    {
        Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model);
        Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id, SuppliersDeleteModel suppliersDelete);
        Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id);
        Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync();
        Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model);

    }
}
