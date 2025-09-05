
namespace PlatformShop.Domain.Models.Products
{
    public record ProductsCreateModel : ProductsModel
    {
        public int CreationUser { get; set; }
    }
}
