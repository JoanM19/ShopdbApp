

using Microsoft.Extensions.Logging;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Application.Services
{
    public class ShippersService : IShippersService
    {
        private readonly IShippersRepository _shippersRepository;
        private readonly ILogger<ShippersService> _logger;
        public ShippersService(IShippersRepository shippersRepository, ILogger<ShippersService> logger)
        {
            _shippersRepository = shippersRepository;
            _logger = logger;
        }
        public async Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model)
        {
            return await _shippersRepository.CreateShipperAsync(model);
        }

        public async Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id, ShippersDeleteModel shippersDelete)
        {
            return await _shippersRepository.DeleteShipperAsync(id, shippersDelete);
        }

        public async Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync()
        {
            return await _shippersRepository.GetAllShippersAsync();
        }

        public async Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id)
        {
            return await _shippersRepository.GetShipperByIdAsync(id);
        }

        public async Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model)
        {
            return await _shippersRepository.UpdateShipperAsync(id, model);
        }
    }
}
