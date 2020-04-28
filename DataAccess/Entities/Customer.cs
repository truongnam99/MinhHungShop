using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Feedback = new HashSet<Feedback>();
            Orders = new HashSet<Orders>();
            ReceivingInfo = new HashSet<ReceivingInfo>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<ReceivingInfo> ReceivingInfo { get; set; }
    }
}
