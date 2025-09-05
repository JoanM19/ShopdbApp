

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersCreateModel : CustomersModel
    {
        
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int CreationUser { get; set; }

    }
}
