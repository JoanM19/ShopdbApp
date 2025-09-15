
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Employees;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;

namespace PlatformShop.Persistence.Repositories.Employees
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        public EmployeesRepository(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public async Task<OperationResult<EmployesCreateModel>> CreateEmployeesAsync(EmployesCreateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_firstname"] = model.FirstName,
                ["@p_lastname"] = model.LastName,
                ["@p_title"] = model.Title,
                ["@p_titleofcourtesy "] = model.Titleofcourtesy,
                ["@p_birthdate"] = model.BirthDate,
                ["@p_hiredate"] = model.HireDate,
                ["@p_address"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_mgrid"] = model.Mgrid,
                ["@p_creation_date"] = model.CreationDate,
                ["@p_creation_user"] = model.CreationUser
            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[InsertarEmployee]", parameters);

            var result = new OperationResult<EmployesCreateModel>();
            //se retorna el cliente insertado
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo insertar el empleado";
            }
            return result;
        }

        public async Task<OperationResult<EmployeesDeleteModel>> DeleteEmployeesAsync(int id, EmployeesDeleteModel employeesDelete)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_empid"] = employeesDelete.Empid,
                ["@p_delete_user"] = employeesDelete.DeleteUser,
                ["@p_delete_date"] = employeesDelete.DeleteDate
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[EliminarEmployee]", parameters);

            var result = new OperationResult<EmployeesDeleteModel>();

            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = employeesDelete; // retornas el cliente eliminado
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo eliminar el empleado";
            }
            return result;
        }

        public async Task<OperationResult<List<EmployeesGetModel>>> GetAllEmployeesAsync()
        {
            var Employees = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerEmployees]", reader => new EmployeesGetModel
            {
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region")),
                PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Mgrid = reader.IsDBNull(reader.GetOrdinal("Mgrid")) ? null : reader.GetString(reader.GetOrdinal("Mgrid"))
            });
            return new OperationResult<List<EmployeesGetModel>>
            {
                IsSuccess = true,
                Data = Employees
            };
        }

        public async Task<OperationResult<EmployeesGetModel>> GetEmployeesByIdAsync(int id)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_empid"] = id
            };
            var Employees = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerEmployeePorId]", reader => new EmployeesGetModel
            {
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region")),
                PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Mgrid = reader.IsDBNull(reader.GetOrdinal("Mgrid")) ? null : reader.GetString(reader.GetOrdinal("Mgrid"))
            }, parameters);
            var Employee = Employees.FirstOrDefault();
            if (Employee == null)
            {
                return new OperationResult<EmployeesGetModel>
                {
                    IsSuccess = false,
                    Message = "Empleado no encontrado"
                };
            }
            else
            {
                return new OperationResult<EmployeesGetModel>
                {
                    IsSuccess = true,
                    Data = Employee
                };
            }
        }

        public async Task<OperationResult<EmployeesUpdateModel>> UpdateEmployeesAsync(int id, EmployeesUpdateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_empid"] = model.Empid,
                ["@p_firstname"] = model.FirstName,
                ["@p_lastname"] = model.LastName,
                ["@p_title"] = model.Title,
                ["@p_birthdate"] = model.BirthDate,
                ["@p_hiredate"] = model.HireDate,
                ["@p_address"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_mgrid"] = model.Mgrid,
                ["@p_modify_date"] = model.ModifyDate,
                ["@p_modify_user"] = model.ModifyUser
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[ActualizarEmployee]", parameters);
            var result = new OperationResult<EmployeesUpdateModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model; // retornas el cliente actualizado
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo actualizar el empleado";
            }
            return result;
        }
    }
}
