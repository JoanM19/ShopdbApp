
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Customers;

namespace PlatformShop.Domain.Repositories
{
    interface ICustomersRepository
    {
        Task<OperationResult<List<CustomersGetModel>>> GetAllCustomersAsync();
        Task<OperationResult<CustomersGetModel>> GetCustomerByIdAsync(int id);
        Task<OperationResult<CustomersCreateModel>> CreateCustomerAsync(CustomersCreateModel model);
        Task<OperationResult<CustomersUpdateModel>> UpdateCustomerAsync(int id, CustomersUpdateModel model);
        Task<OperationResult<CustomersDeleteModel>> DeleteCustomerAsync(int id);
    }
}
