

namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersGetModel : SuppliersModel
    {
        public int Supplierid { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
