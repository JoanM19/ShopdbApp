

using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;

namespace PlatformShop.Application.Contracts
{
    public interface IEmployeesService
    {
        Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model);
        Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id, EmployeesDeleteModel employeesDelete);
        Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync();
        Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id);
        Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model);
    }
}
