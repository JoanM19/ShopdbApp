
namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersDeleteModel
    {
        public int SupplierId { get; set; }
        public int DeleteUser { get; set; }
    }
}
