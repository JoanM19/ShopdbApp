using PlatformShop.Domain.Entities;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Models.Products;

namespace PlatformShop.Domain.Repositories
{
    public interface IProductRepository 
    {
        Task<OperationResult<List<ProductsGetModel>>> GetAllProductsAsync();
        Task<OperationResult<ProductsGetModel>> GetProductByIdAsync(int id);
        Task<OperationResult<ProductsCreateModel>> CreateProductAsync(ProductsCreateModel model);
        Task<OperationResult<ProductsUpdateModel>> UpdateProductAsync(int id, ProductsUpdateModel model);
        Task<OperationResult<ProductsDeleteModel>> DeleteProductAsync(int id);
    }
}
