
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;

namespace PlatformShop.Domain.Repositories
{
    public interface IEmployeesRepository
    {
        Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model);
        Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id, EmployeesDeleteModel employeesDelete);
        Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync();
        Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id);
        Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model);
        
    }
}
