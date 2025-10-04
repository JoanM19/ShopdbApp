

namespace PlatformShop.Domain.Models.Shippers
{
    public record ShippersModel
    {
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string?  Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Postalcode { get; set; }

        public string? Country { get; set; }
    }
}
