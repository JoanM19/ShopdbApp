
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Persistence.Repositories.Employees
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
