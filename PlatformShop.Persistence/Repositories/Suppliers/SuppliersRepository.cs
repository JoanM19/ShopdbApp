
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Suppliers;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;
using System.Data;

namespace PlatformShop.Persistence.Repositories.Suppliers
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        public SuppliersRepository(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }
        public async Task<OperationResult<SuppliersCreateModel>> CreateSupplierAsync(SuppliersCreateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_companyname"] = model.CompanyName,
                ["@p_contactname"] = model.ContactName,
                ["@p_contacttitle"] = model.ContactTitle,
                ["@p_address"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_fax"] = model.Fax,
                ["@p_creation_user"] = model.CreationUser
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[InsertarSupplier]", parameters);
            var result = new OperationResult<SuppliersCreateModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model; 
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo insertar el proveedor";
            }
            return result;
        }

        public async Task<OperationResult<SuppliersDeleteModel>> DeleteSupplierAsync(int id, SuppliersDeleteModel suppliersDelete)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_supplierid"] = suppliersDelete.SupplierId,
                ["@p_delete_user"] = suppliersDelete.DeleteUser
            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[EliminarSupplier]", parameters);

            var result = new OperationResult<SuppliersDeleteModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = suppliersDelete;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo eliminar el proveedor";
            }
            return result;
        }

        public async Task<OperationResult<List<SuppliersGetModel>>> GetAllSuppliersAsync()
        {
            var shippers = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerSuppliers]", reader => new SuppliersGetModel
            {
                SupplierId = reader.GetInt32("SupplierID"),
                CompanyName = reader.GetString("CompanyName"),
                ContactName = reader.IsDBNull("ContactName") ? null : reader.GetString("ContactName"),
                ContactTitle = reader.IsDBNull("ContactTitle") ? null : reader.GetString("ContactTitle"),
                Address = reader.IsDBNull("Address") ? null : reader.GetString("Address"),
                City = reader.IsDBNull("City") ? null : reader.GetString("City"),
                Region = reader.IsDBNull("Region") ? null : reader.GetString("Region"),
                PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString("PostalCode"),
                Country = reader.IsDBNull("Country") ? null : reader.GetString("Country"),
                Phone = reader.IsDBNull("Phone") ? null : reader.GetString("Phone"),
                Fax = reader.IsDBNull("Fax") ? null : reader.GetString("Fax"),
               
            });
            return new OperationResult<List<SuppliersGetModel>>
            {
                IsSuccess = true,
                Data = shippers
            };

        }

        public async Task<OperationResult<SuppliersGetModel>> GetSupplierByIdAsync(int id)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_supplierid"] = id
            };
            var shippers = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerSupplierPorId]", reader => new SuppliersGetModel
            {
                SupplierId = reader.GetInt32("SupplierID"),
                CompanyName = reader.GetString("CompanyName"),
                ContactName = reader.IsDBNull("ContactName") ? null : reader.GetString("ContactName"),
                ContactTitle = reader.IsDBNull("ContactTitle") ? null : reader.GetString("ContactTitle"),
                Address = reader.IsDBNull("Address") ? null : reader.GetString("Address"),
                City = reader.IsDBNull("City") ? null : reader.GetString("City"),
                Region = reader.IsDBNull("Region") ? null : reader.GetString("Region"),
                PostalCode = reader.IsDBNull("PostalCode") ? null : reader.GetString("PostalCode"),
                Country = reader.IsDBNull("Country") ? null : reader.GetString("Country"),
                Phone = reader.IsDBNull("Phone") ? null : reader.GetString("Phone"),
                Fax = reader.IsDBNull("Fax") ? null : reader.GetString("Fax"),
            }, parameters);
            var shipper = shippers.FirstOrDefault();
            if (shipper == null)
            {
                return new OperationResult<SuppliersGetModel>
                {
                    IsSuccess = false,
                    Message = "No se encontró el proveedor"
                };
            }
            return new OperationResult<SuppliersGetModel>
            {
                IsSuccess = true,
                Data = shipper
            };

        }

        public async Task<OperationResult<SuppliersUpdateModel>> UpdateSupplierAsync(int id, SuppliersUpdateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_supplierid"] = id,
                ["@p_companyname"] = model.CompanyName,
                ["@p_contactname"] = model.ContactName,
                ["@p_contacttitle"] = model.ContactTitle,
                ["@p_address"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.PostalCode,
                ["@p_country"] = model.Country,
                ["@p_phone"] = model.Phone,
                ["@p_fax"] = model.Fax,
                ["@p_modify_user"] = model.ModifyUser
            };

            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[ActualizarSupplier]", parameters);

            var result = new OperationResult<SuppliersUpdateModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo actualizar el proveedor";
            }
            return result;
        }
    }
}
