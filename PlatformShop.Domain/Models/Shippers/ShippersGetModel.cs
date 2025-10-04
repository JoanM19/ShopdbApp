


namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersGetModel : ShippersModel
    {
        public int Shipperid { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string? DeleteUser { get; set; }
        public object DeleteDate { get; set; }
    }
}
