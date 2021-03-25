using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class Producer
    {
        public Producer()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
