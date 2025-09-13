

using Microsoft.Extensions.Logging;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Customers;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ICustomersRepository customersRepository, ILogger<CustomersService> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public async Task<OperationResult<CustomersCreateModel>> CreateCustomersAsync(CustomersCreateModel model)
        {
            return await _customersRepository.CreateCustomerAsync(model);
        }

        public async Task<OperationResult<CustomersDeleteModel>> DeleteCustomersAsync(int id, CustomersDeleteModel model)
        {
            return await _customersRepository.DeleteCustomerAsync(id, model);
        }

        public async Task<OperationResult<List<CustomersGetModel>>> GetAllCustomersAsync()
        {
            return await _customersRepository.GetAllCustomersAsync();
        }

        public async Task<OperationResult<CustomersGetModel>> GetCustomersByIdAsync(int id)
        {
            return await _customersRepository.GetCustomerByIdAsync(id);
        }

        public async Task<OperationResult<CustomersUpdateModel>> UpdateCustomersAsync(int id, CustomersUpdateModel model)
        {
            return await _customersRepository.UpdateCustomerAsync(id, model);
        }
    }
}
