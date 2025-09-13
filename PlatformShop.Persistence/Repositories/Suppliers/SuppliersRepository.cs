
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Persistence.Repositories.Suppliers
{
    public class SuppliersRepository : ISuppliersRepository
    {
        public Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
