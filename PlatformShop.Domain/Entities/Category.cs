using PlatformShop.Domain.Base;

namespace PlatformShop.Domain.Entities
{
    public class Category : UserDetails
    {
        public int Categoryid { get; set; }

        public string? Categoryname { get; set; }

        public string? Description { get; set; }

        
    }
}

