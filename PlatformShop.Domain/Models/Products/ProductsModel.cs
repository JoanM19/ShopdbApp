

namespace PlatformShop.Domain.Models.Products
{
    public record ProductsModel
    {
        public string? Productname { get; set; }

        public int Supplierid { get; set; }

        public int Categoryid { get; set; }

        public decimal Unitprice { get; set; }

        public bool Discontinued { get; set; }
    }
}
