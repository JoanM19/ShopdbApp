
namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersUpdateModel
    {
        public int Shipperid { get; set; }
        public int? ModifyUser { get; set; }
    }
}
