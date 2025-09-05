
using PlatformShop.Domain.Base;

namespace PlatformShop.Domain.Entities
{
    public class Shipper : UserDetails
    {
        public int Shipperid { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Postalcode { get; set; }

        public int? Country { get; set; }

    }
}

