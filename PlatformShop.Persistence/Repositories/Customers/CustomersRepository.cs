using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Customers;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;

namespace PlatformShop.Persistence.Repositories.Customers
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        public CustomersRepository(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public async Task<OperationResult<CustomersCreateModel>> CreateCustomerAsync(CustomersCreateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_companyname"] = model.CompanyName,
                ["@p_contactname"] = model.ContactName,
                ["@p_contacttitle"] = model.ContactTitle,
                ["@p_address"] = model.Address,
                ["@p_email"] = model.Email,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_fax"] = model.Fax,
                ["@p_creation_date"] = model.CreationDate,
                ["@p_creation_user"] = model.CreationUser

            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[InsertarCustomer]", parameters);

            var result = new OperationResult<CustomersCreateModel>();

            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model; // retornas el cliente insertado
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo insertar el cliente";
            }

            return result;

        }
       
        public async Task<OperationResult<CustomersDeleteModel>> DeleteCustomerAsync(int id, CustomersDeleteModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_custid"] = model.custid,
                ["@p_delete_user"] = model.DeleteUser,
                ["@p_delete_date"] = model.DeleteDate

            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[EliminarCustomer]", parameters);

            var result = new OperationResult<CustomersDeleteModel>();

            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = new CustomersDeleteModel {custid = id };
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo eliminar el cliente";
            }

            return result;
        }

        public async Task<OperationResult<List<CustomersGetModel>>> GetAllCustomersAsync()
        {

            var customers = await _storedProcedureExecutor.QueryAsync(
                "[dbo].[ObtenerCustomers]",
                reader => new CustomersGetModel
                {
                    custid = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                    ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                    ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    City = reader.GetString(reader.GetOrdinal("City")),
                    Region = reader.GetString(reader.GetOrdinal("Region")),
                    PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                    Country = reader.GetString(reader.GetOrdinal("Country")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    Fax = reader.GetString(reader.GetOrdinal("Fax"))
                });

            return new OperationResult<List<CustomersGetModel>>
            {
                IsSuccess = true,
                Data = customers
            };
        }

        public async Task<OperationResult<CustomersGetModel>> GetCustomerByIdAsync(int id)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_customerId"] = id
            };

            var customers = await _storedProcedureExecutor.QueryAsync(
                "[dbo].[ObtenerCustomerPorId]",
                reader => new CustomersGetModel
                {
                    custid = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                    ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                    ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    City = reader.GetString(reader.GetOrdinal("City")),
                    Region = reader.GetString(reader.GetOrdinal("Region")),
                    PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                    Country = reader.GetString(reader.GetOrdinal("Country")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    Fax = reader.GetString(reader.GetOrdinal("Fax"))
                },
                parameters);

            var customer = customers.FirstOrDefault();

            if (customer == null)
            {
                return new OperationResult<CustomersGetModel>
            {
                IsSuccess = customer != null,
                Data = customer,
                Message = "Cliente no encontrado"
                };
            }
            else
            { 
                return new OperationResult<CustomersGetModel>
            {
                IsSuccess = customer != null,
                Data = customer,
                Message = null
                };
            }

        }

        public async Task<OperationResult<CustomersUpdateModel>> UpdateCustomerAsync(int id, CustomersUpdateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_custid"] = model.custid,
                ["@p_companyname"] = model.CompanyName,
                ["@p_contactname"] = model.ContactName,
                ["@p_contacttitle"] = model.ContactTitle,
                ["@p_address"] = model.Address,
                ["@p_email"] = model.Email,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_fax"] = model.Fax,
                ["@p_modify_user"] = model.Modify_User,
                ["@p_modify_date"] = model.Modify_Date
            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[ActualizarCustomer]", parameters);

            var result = new OperationResult<CustomersUpdateModel>();

            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo actualizar el cliente";
            }

            return result;
        }
    }
}
