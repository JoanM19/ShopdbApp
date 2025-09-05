using PlatformShop.Domain.Base;

namespace PlatformShop.Domain.Entities
{
    public class Product : UserDetails
    {
        public int Productid { get; set; }

        public string? Productname { get; set; }

        public int Supplierid { get; set; }

        public int Categoryid { get; set; }

        public decimal Unitprice { get; set; }

        public bool Discontinued { get; set; }

       
    }

}

