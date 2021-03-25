using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class ReceivingInfo
    {
        public long Id { get; set; }
        public long? Idcus { get; set; }
        public string RecipientName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Customer IdcusNavigation { get; set; }
    }
}
