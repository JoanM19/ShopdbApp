

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersDeleteModel
    {
        public int custid { get; set; }
        public int DeleteUser { get; set; }
        public DateTime DeleteDate { get; set; } = DateTime.UtcNow;
    }
}
