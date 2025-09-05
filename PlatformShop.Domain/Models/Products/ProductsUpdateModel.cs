

namespace PlatformShop.Domain.Models.Products
{
    public record ProductsUpdateModel : ProductsModel
    {
        public int Productid { get; set; }
        public int? ModifyUser { get; set; }
    }
}
