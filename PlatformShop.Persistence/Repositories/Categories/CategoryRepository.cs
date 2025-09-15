
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Repositories;
using PlatformShop.Domain.Models.Categories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using PlatformShop.Persistence.Repositories.Base;
using PlatformShop.Domain.Models.Customers;

namespace PlatformShop.Persistence.Repositories.Categories
{
    public class CategoryRepository : ICategoriesRepository
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public CategoryRepository(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public async Task<OperationResult<CategoriesCreateModel>> CreateCategoriesAsync(CategoriesCreateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_categoryname"] = model.CategoryName,
                ["@p_description"] = model.Description,
                ["@p_creation_date"] = model.CreationDate,
                ["@p_creation_user"] = model.CreationUser
            };
            int rowsAffected = await _storedProcedureExecutor.ExecuteAsync("[dbo].[InsertarCategoria]", parameters);

            var result = new OperationResult<CategoriesCreateModel>();

            if (rowsAffected > 0)
            {
                result.IsSuccess = true;
                result.Data = model; 
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Could not insert the category";
            }
            return result;
        }

        public async Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id, CategoriesDeleteModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_categoryid"] = model.CategoryID,
                ["@p_delete_date"] = model.Deletion_Date,
                ["@_delete_user"] = model.Deletion_User
            };
            int rowsAffected = await _storedProcedureExecutor.ExecuteAsync("[dbo].[EliminarCategoria]", parameters);

            var result = new OperationResult<CategoriesDeleteModel>();

            if (rowsAffected > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Could not delete the category";
            }
            return result;
        }

        public async Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync()
        {
            var categories = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerCategories]", reader => new CategoriesGetModel {
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
            });
            
            
            return new OperationResult<List<CategoriesGetModel>>
            {
                IsSuccess = true,
                Data = categories
            };
        }

        public async Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_categoryid"] = id
            };
            var categories = await _storedProcedureExecutor.QueryAsync("[dbo].[ObtenerCategoryPorId]", reader => new CategoriesGetModel
            {
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
            }, parameters);

            var category = categories.FirstOrDefault();

            var result = new OperationResult<CategoriesGetModel>();

            if (category != null)
            {
                result.IsSuccess = true;
                result.Data = category;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Category not found";
            }
            return result;
        }

        public async Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesUpdateModel model)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["@p_categoryid"] = id,
                ["@p_categoryname"] = model.CategoryName,
                ["@p_description"] = model.Description,
                ["@p_modify_date"] = model.Modified_Date,
                ["@p_modify_user"] = model.Modified_User
            };
            int rowsAffected = await _storedProcedureExecutor.ExecuteAsync("[dbo].[ActualizarCategoria]", parameters);
            var result = new OperationResult<CategoriesUpdateModel>();
            if (rowsAffected > 0)
            {
                result.IsSuccess = true;
                result.Data = model;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Could not update the category";
            }
            return result;
        }
    }
}