

namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersGetModel : ShippersModel
    {
        public int Shipperid { get; set; }
        public int CreationUser { get; set; }
    }
}
