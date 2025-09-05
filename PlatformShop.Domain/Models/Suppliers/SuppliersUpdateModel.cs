

namespace PlatformShop.Domain.Models.Suppliers
{
    public record SuppliersUpdateModel : SuppliersModel
    {
        public int Supplierid { get; set; }
        public int ModifyUser { get; set; }
    }
}
