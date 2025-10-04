using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Categories;
using PlatformShop.Domain.Models.Customers;

namespace PlatformShop.Application.Contracts
{
    public interface ICustomersService
    {
        Task<OperationResult<CustomersCreateModel>> CreateCustomersAsync(CustomersCreateModel model);
        Task<OperationResult<CustomersDeleteModel>> DeleteCustomersAsync(int id, CustomersDeleteModel model);
        Task<OperationResult<List<CustomersGetModel>>> GetAllCustomersAsync();
        Task<OperationResult<CustomersGetModel>> GetCustomersByIdAsync(int id);
        Task<OperationResult<CustomersUpdateModel>> UpdateCustomersAsync(int id, CustomersUpdateModel model);
    }
}
