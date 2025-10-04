using PlatformShop.Domain.Entities;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Categories;

namespace PlatformShop.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        Task<OperationResult<CategoriesCreateModel>> CreateCategoriesAsync(CategoriesCreateModel model);
        Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id, CategoriesDeleteModel model);
        Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync();
        Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id);
        Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesUpdateModel model);

    }
}
