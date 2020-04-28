using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class OrderDetail
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public Orders Order { get; set; }
        public Product Product { get; set; }
    }
}
