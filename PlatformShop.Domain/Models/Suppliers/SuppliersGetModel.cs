

namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersGetModel : SuppliersModel
    {
        public int SupplierId { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
