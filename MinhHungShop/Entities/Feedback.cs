using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public long? Idcus { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public Customer IdcusNavigation { get; set; }
    }
}
