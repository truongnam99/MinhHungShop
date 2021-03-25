using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? CustomerId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
