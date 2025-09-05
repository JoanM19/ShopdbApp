﻿
namespace PlatformShop.Domain.Entities
{
    public sealed class OrderDetail
    {
        public int Orderid { get; set; }

        public int Productid { get; set; }

        public decimal Unitprice { get; set; }

        public short Qty { get; set; }

        public decimal Discount { get; set; }
    }
}

