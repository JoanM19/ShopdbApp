
namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersCreateModel : ShippersModel
    {
        public int CreationUser { get; set; }
    }
}
