
namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersDeleteModel
    {
        public int Supplierid { get; set; }
        public int DeleteUser { get; set; }
    }
}
