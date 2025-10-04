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
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoriesRepository categoriesRepository, ILogger<CategoryService> logger)
        {
            _categoriesRepository = categoriesRepository;
            _logger = logger;
        }

        public async Task<OperationResult<CategoriesCreateModel>> CreateCategoriesAsync(CategoriesCreateModel model)
        {
            return await _categoriesRepository.CreateCategoriesAsync(model);
        }

        public async Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id, CategoriesDeleteModel model)
        {
            return await _categoriesRepository.DeleteCategoriesAsync(id, model);
        }

        public async Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync()
        {
            return await _categoriesRepository.GetAllCategoriesAsync();
        }

        public async Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id)
        {
            return await _categoriesRepository.GetCategoriesByIdAsync(id);
        }

        public async Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesUpdateModel model)
        {
            return await _categoriesRepository.UpdateCategoriesAsync(id, model);
        }
    }
}
