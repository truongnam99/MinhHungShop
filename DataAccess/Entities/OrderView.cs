using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class OrderView
    {
        public long OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public bool? Status { get; set; }
    }
}
