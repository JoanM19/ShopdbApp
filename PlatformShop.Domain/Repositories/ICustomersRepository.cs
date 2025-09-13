
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Customers;

namespace PlatformShop.Domain.Repositories
{
    public interface ICustomersRepository
    {
        Task<OperationResult<CustomersCreateModel>> CreateCustomerAsync(CustomersCreateModel model);
        Task<OperationResult<CustomersDeleteModel>> DeleteCustomerAsync(int id, CustomersDeleteModel model);
        Task<OperationResult<List<CustomersGetModel>>> GetAllCustomersAsync();
        Task<OperationResult<CustomersGetModel>> GetCustomerByIdAsync(int id);
        Task<OperationResult<CustomersUpdateModel>> UpdateCustomerAsync(int id, CustomersUpdateModel model);
    }
}
