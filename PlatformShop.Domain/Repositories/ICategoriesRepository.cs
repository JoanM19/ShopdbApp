
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Categories;

namespace PlatformShop.Domain.Repositories
{
    interface ICategoriesRepository
    {
        Task<OperationResult<List<CategoriesGetModel>>> GetAllCategoriesAsync();
        Task<OperationResult<CategoriesGetModel>> GetCategoriesByIdAsync(int id);
        Task<OperationResult<CategoriesCreateModel>> CreateCategoriesAsync(CategoriesGetModel model);

        Task<OperationResult<CategoriesUpdateModel>> UpdateCategoriesAsync(int id, CategoriesGetModel model);

        Task<OperationResult<CategoriesDeleteModel>> DeleteCategoriesAsync(int id);
    }
}
