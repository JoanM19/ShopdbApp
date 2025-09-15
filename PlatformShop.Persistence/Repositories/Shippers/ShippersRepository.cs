

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Shippers;
using PlatformShop.Domain.Repositories;
using PlatformShop.Persistence.Repositories.Base;
using System.Data;

namespace PlatformShop.Persistence.Repositories.Shippers
{
    public class ShippersRepository : IShippersRepository
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        public ShippersRepository(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }
        public async  Task<OperationResult<ShippersCreateModel>> CreateShipperAsync(ShippersCreateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_name"] = model.Name,
                ["@p_phone"] = model.Phone,
                ["@p_adress"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.Postalcode,
                ["@p_country"] = model.Country,
                ["@p_creation_user"] = model.CreationUser
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[InsertarShipper]", parameters);

            var result = new OperationResult<ShippersCreateModel>();

            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model; 
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo insertar el transportista";
            }
            return result;

        }

        public async Task<OperationResult<ShippersDeleteModel>> DeleteShipperAsync(int id, ShippersDeleteModel shippersDelete)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_shipperid"] = shippersDelete.Shipperid,
                ["@p_delete_user"] = shippersDelete.DeleteUser
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[EliminarShippers]", parameters);
            var result = new OperationResult<ShippersDeleteModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = shippersDelete;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo eliminar el transportista";
            }
            return result;
        }

        public async Task<OperationResult<List<ShippersGetModel>>> GetAllShippersAsync()
        {
            var shippers = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerShippers]", reader => new ShippersGetModel
            {
                Shipperid = reader.GetInt32("shipperid"),
                Name = reader.GetString("name"),
                Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                Address = reader.IsDBNull("address") ? null : reader.GetString("address"),
                City = reader.IsDBNull("city") ? null : reader.GetString("city"),
                Region = reader.IsDBNull("region") ? null : reader.GetString("region"),
                Postalcode = reader.IsDBNull("postalcode") ? null : reader.GetString("postalcode"),
                Country = reader.IsDBNull("country") ? null : reader.GetString("country"),
                CreationUser = reader.GetInt32("creation_user"),
                CreationDate = reader.GetDateTime("creation_date"),
                DeleteUser = reader.IsDBNull("delete_user") ? null : reader.GetString("delete_user"),
                DeleteDate = reader.IsDBNull("delete_date") ? null : reader.GetDateTime("delete_date")

            });
            var result = new OperationResult<List<ShippersGetModel>>();
            if (shippers.Count > 0)
            {
                result.IsSuccess = true;
                result.Data = shippers;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se encontraron transportistas";
            }
            return result;
        }

        public async Task<OperationResult<ShippersGetModel>> GetShipperByIdAsync(int id)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_shipperid"] = id
            };
            var shippers = _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerShipperPorId]", reader => new ShippersGetModel
            {
                Shipperid = reader.GetInt32("shipperid"),
                Name = reader.GetString("name"),
                Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                Address = reader.IsDBNull("address") ? null : reader.GetString("address"),
                City = reader.IsDBNull("city") ? null : reader.GetString("city"),
                Region = reader.IsDBNull("region") ? null : reader.GetString("region"),
                Postalcode = reader.IsDBNull("postalcode") ? null : reader.GetString("postalcode"),
                Country = reader.IsDBNull("country") ? null : reader.GetString("country"),
                CreationUser = reader.GetInt32("creation_user"),
                CreationDate = reader.GetDateTime("creation_date"),
                DeleteUser = reader.IsDBNull("delete_user") ? null : reader.GetString("delete_user"),
                DeleteDate = reader.IsDBNull("delete_date") ? null : reader.GetDateTime("delete_date")
            }, parameters);

           var result = new OperationResult<ShippersGetModel>();
            if (shippers.Result.Count > 0)
            {
                result.IsSuccess = true;
                result.Data = shippers.Result.First();
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se encontro el transportista";
            }
            return result;
        }

        public async Task<OperationResult<ShippersUpdateModel>> UpdateShipperAsync(int id, ShippersUpdateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_shipperid"] = model.Shipperid,
                ["@p_name"] = model.Name,
                ["@p_phone"] = model.Phone,
                ["@p_adress"] = model.Address,
                ["@p_city"] = model.City,
                ["@p_region"] = model.Region,
                ["@p_postalcode"] = model.Postalcode,
                ["@p_country"] = model.Country,
                ["@p_modify_user"] = model.ModifyUser
            };
            int filas = await _storedProcedureExecutor.ExecuteAsync("[dbo].[ActualizarShippers]", parameters);
            var result = new OperationResult<ShippersUpdateModel>();
            if (filas > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No se pudo actualizar el transportista";
            }
            return result;
        }
    }
}
