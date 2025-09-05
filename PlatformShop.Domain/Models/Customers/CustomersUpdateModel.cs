

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersUpdateModel : CustomersCreateModel
    {
        public int custid { get; set; }
        public DateTime? Modify_User { get; set; }
        public int? Modify_Date { get; set; }
    }
}
