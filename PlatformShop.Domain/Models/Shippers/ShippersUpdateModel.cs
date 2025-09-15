
namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersUpdateModel : ShippersModel
    {
        public int Shipperid { get; set; }
        public int? ModifyUser { get; set; }
    }
}
