

using System;

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersUpdateModel : CustomersModel
    {
        public int custid { get; set; }
        public DateTime? Modify_Date { get; set; }
        public int? Modify_User { get; set; }
    }
}
