

using Microsoft.Extensions.Logging;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ILogger<EmployeesService> _logger;
        public EmployeesService(IEmployeesRepository employeesRepository, ILogger<EmployeesService> logger)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;
        }
        public async Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model)
        {
            return await _employeesRepository.CreateEmployeesAsync(model);
        }

        public async Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id, EmployeesDeleteModel employeesDelete)
        {
            return await _employeesRepository.DeleteEmployeesAsync(id, employeesDelete);
        }

        public async Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync()
        {
            return await _employeesRepository.GetAllEmployeesAsync();
        }

        public async Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id)
        {
            return await _employeesRepository.GetEmployeesByIdAsync(id);
        }

        public async Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model)
        {
            return await _employeesRepository.UpdateEmployeesAsync(id, model);
        }
    }
}
