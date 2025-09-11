
using PlatformShop.Domain.Models;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Categories;

namespace PlatformShop.Application.Contracts
{
    public interface ICategoryService
    {
        Task<OperationResult<CategoriesGetModel>> GetCategory();

        Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync();
        Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id);
        Task<OperationResult<CategoriesUpdateModel>> CreateCategoriesAsync(CategoriesCreateModel model);

        Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesGetModel model);

        Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id);
    }
}
