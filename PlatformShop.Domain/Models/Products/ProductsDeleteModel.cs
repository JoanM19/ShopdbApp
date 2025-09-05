

namespace PlatformShop.Domain.Models.Products
{
    public record ProductsDeleteModel
    {
        public int Productid { get; set; }
        public int? DeleteUser { get; set; }
    }
}
