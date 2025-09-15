

using Microsoft.Extensions.Logging;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ILogger<SupplierService> _logger;
        public SupplierService(ISuppliersRepository suppliersRepository, ILogger<SupplierService> logger)
        {
            _suppliersRepository = suppliersRepository;
            _logger = logger;
        }
        public async Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model)
        {
            return await _suppliersRepository.CreateSupplierAsync(model);
        }

        public async Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id, SuppliersDeleteModel suppliersDelete)
        {
            return await _suppliersRepository.DeleteSupplierAsync(id, suppliersDelete);
        }

        public async Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync()
        {
            return await _suppliersRepository.GetAllSuppliersAsync();
        }

        public async Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id)
        {
            return await _suppliersRepository.GetSupplierByIdAsync(id);
        }

        public async Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model)
        {
            return await _suppliersRepository.UpdateSupplierAsync(id, model);
        }
    }
}
