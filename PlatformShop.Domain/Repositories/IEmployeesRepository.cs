
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;

namespace PlatformShop.Domain.Repositories
{
    interface IEmployeesRepository
    {
        Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync();
        Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id);
        Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model);
        Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model);
        Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id);

    }
}
