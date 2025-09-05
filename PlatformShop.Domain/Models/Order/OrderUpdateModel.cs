
namespace PlatformShop.Domain.Models.Order
{
    public record OrderUpdateModel : OrderModel
    {
        public int Orderid { get; set; }   
    }
}
