

namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersCreateModel : SuppliersModel
    {

        public int CreationUser { get; set; }
    }
}
