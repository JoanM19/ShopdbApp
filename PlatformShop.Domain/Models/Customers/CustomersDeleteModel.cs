

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersDeleteModel
    {
        public int custid { get; set; }
        public int DeletionUser { get; set; }
        public DateTime DeletionDate { get; set; } = DateTime.UtcNow;
    }
}
