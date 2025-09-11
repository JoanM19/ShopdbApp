using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Repositories;
using PlatformShop.Domain.Models.Categories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PlatformShop.Persistence.Repositories.Categories
{
    public class CategoryRepository : ICategoriesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryRepository> _logger;
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration, ILogger<CategoryRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _connectionString = _configuration.GetConnectionString("ShopDbApp");
        }

        public async Task<OperationResult<CategoriesUpdateModel>> CreateCategoriesAsync(CategoriesCreateModel model)
        {
            OperationResult<CategoriesUpdateModel> result = new OperationResult<CategoriesUpdateModel>();

            try
            {
                if (model == null)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category model is null.");
                }
                if (string.IsNullOrEmpty(model.CategoryName) || string.IsNullOrWhiteSpace(model.CategoryName))
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name is required.");
                }
                if (model.CreationUser <= 0)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The CreationUser is required and must be greater than zero.");
                }
                if (model.CreationDate == DateTime.MinValue)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The CreationDate is required and must be a valid date.");
                }
                if (model.Description != null && model.Description.Length > 500)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Description cannot exceed 500 characters.");
                }
                if (model.CategoryName.Length > 100)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name cannot exceed 100 characters.");
                }
                if (model.CategoryName.Length < 3)
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name must be at least 3 characters long.");
                }
                if (model.CategoryName.Any(char.IsDigit))
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name cannot contain numbers.");
                }
                if (model.CategoryName.Any(char.IsSymbol))
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name cannot contain special characters.");
                }
                if (model.CategoryName.Any(char.IsPunctuation))
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name cannot contain punctuation characters.");
                }
                if (model.CategoryName.Any(char.IsWhiteSpace))
                {
                    return OperationResult<CategoriesUpdateModel>.Failure("The Category name cannot contain whitespace characters.");
                }

                _logger.LogInformation($"Creating a new category: {model.CategoryName}");

                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[InsertarCategoria]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_categoryname", model.CategoryName);
                        command.Parameters.AddWithValue("@p_description", model.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@p_creation_user", model.CreationUser);
                        command.Parameters.AddWithValue("@p_creation_date", model.CreationDate);
                        

                        SqlParameter p_result = new SqlParameter("@p_result", System.Data.SqlDbType.NVarChar)
                        {
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(p_result);

                        await connection.OpenAsync();

                        var rowsAffected = await command.ExecuteNonQueryAsync();
                        var resultMessage = p_result.Value.ToString();

                        if (rowsAffected > 0)
                        {
                            _logger.LogInformation($"Category successfully: {model.CategoryName}. Result: {resultMessage}");
                            var createdCategory = new CategoriesUpdateModel
                            {
                                CategoryName = model.CategoryName,
                                Description = model.Description,
                                Modified_Date = model.CreationDate,
                                Modified_User = model.CreationUser
                            };
                            result = OperationResult<CategoriesUpdateModel>.Success("Category created successfully.", createdCategory);
                        }
                        else
                        {
                            _logger.LogWarning($"No rows affected while creating category: {model.CategoryName}. Result: {resultMessage}");
                            result = OperationResult<CategoriesUpdateModel>.Failure("Failed to create category.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new category.");
                return OperationResult<CategoriesUpdateModel>.Failure("An error occurred while creating the category.");
            }

            return result;
        }

        public async Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync()
        {
            OperationResult<List<CategoriesGetModel>> result = new OperationResult<List<CategoriesGetModel>>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[InsertarCategoria]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            var categories = new List<CategoriesGetModel>();
                            while (await reader.ReadAsync())
                            {
                                var category = new CategoriesGetModel
                                {
                                    CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                    CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                    CreationUser = reader.GetInt32(reader.GetOrdinal("CreationUser")),
                                };
                                categories.Add(category);
                            }
                            if (categories.Any())
                            {
                                result = OperationResult<List<CategoriesGetModel>>.Success("Categories retrieved successfully.", categories);
                            }
                            else
                            {
                                result = OperationResult<List<CategoriesGetModel>>.Failure("No categories found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories.");
                result = OperationResult<List<CategoriesGetModel>>.Failure($"An error occurred while retrieving categories: {ex.Message}");
            }
            return result;
        }

        public Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesGetModel model)
        {
            OperationResult<CategoriesUpdateModel> result = new OperationResult<CategoriesUpdateModel>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[ActualizarCategoria]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", id);
                        command.Parameters.AddWithValue("@CategoryName", model.CategoryName);
                        command.Parameters.AddWithValue("@Description", model.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Modified_Date", DateTime.Now);
                        command.Parameters.AddWithValue("@Modified_User", model.CreationUser);
                        SqlParameter p_result = new SqlParameter("@p_result", System.Data.SqlDbType.Int)
                        {
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Output
                        };
                        command.Parameters.Add(p_result);

                        await connection.OpenAsync();

                        var rowsAffected = await command.ExecuteNonQueryAsync();
                        var resultMessage = p_result.Value.ToString();
                        if (rowsAffected > 0)
                        {
                            _logger.LogInformation($"Category successfully updated: {model.CategoryName}. Result: {resultMessage}");
                            var updatedCategory = new CategoriesUpdateModel
                            {
                                CategoryID = id,
                                CategoryName = model.CategoryName,
                                Description = model.Description,
                                Modified_Date = DateTime.Now,
                                Modified_User = model.CreationUser
                            };
                            result = OperationResult<CategoriesUpdateModel>.Success("Category updated successfully.", updatedCategory);
                        }
                        else
                        {
                            _logger.LogWarning($"No rows affected while updating category: {model.CategoryName}. Result: {resultMessage}");
                            result = OperationResult<CategoriesUpdateModel>.Failure("Failed to update category.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the category.");
                return OperationResult<CategoriesUpdateModel>.Failure($"An error occurred while updating the category: {ex.Message}");
            }
            return result;
        }
    }
}
