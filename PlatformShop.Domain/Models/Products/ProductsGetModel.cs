
namespace PlatformShop.Domain.Models.Products
{
    public record ProductsGetModel : ProductsModel
    {
        public int Productid { get; set; }
        public int CreationUser { get; set; }  
    }
}
