using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformShop.Domain.Models.Customers
{
    public record CustomersGetModel : CustomersModel
    {
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int CreationUser { get; set; }
    }
}
