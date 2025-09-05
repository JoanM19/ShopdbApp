
namespace PlatformShop.Domain.Models.OrderDetails
{
    public record OrderDetailsDeleteModel
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
    }
}
