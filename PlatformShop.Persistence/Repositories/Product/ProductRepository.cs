using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlatformShop.Domain.Base;
using PlatformShop.Domain.Repositories;
using PlatformShop.Domain.Models.Products;


namespace PlatformShop.Persistence.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductRepository> _logger;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public Task<OperationResult<ProductsCreateModel>> CreateProductAsync(ProductsCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ProductsDeleteModel>> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ProductsGetModel>>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ProductsGetModel>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ProductsUpdateModel>> UpdateProductAsync(int id, ProductsUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
