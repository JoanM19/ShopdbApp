using Microsoft.Extensions.Logging;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Categories;
using PlatformShop.Domain.Repositories;

namespace PlatformShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoryService(ICategoriesRepository categoriesRepository, ILogger<CategoryService> logger)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<OperationResult<CategoriesCreateModel>> CreateCategoriesAsync(CategoriesGetModel model)
        {
            return await _categoriesRepository.CreateCategoriesAsync(model);
        }
        public async Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesGetModel model)
        {
            return await _categoriesRepository.UpdateCategoriesAsync(id, model);
        }

        public Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync()
        {
           return await _categoriesRepository.GetAllCategoriesAsync();
        }

        public Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriesGetModel>> GetCategory()
        {
            throw new NotImplementedException();
        }

        
    }
}
