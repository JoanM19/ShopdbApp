

namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersDeleteModel
    {
        public int Shipperid { get; set; }
        public int DeleteUser { get; set; }
    }
}
