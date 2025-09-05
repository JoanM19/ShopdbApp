

namespace PlatformShop.Domain.Models.Order
{
    public record OrderGetModel : OrderModel
    {
        public int Orderid { get; set; }
    }
}
