using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderModel
    {
        public Products products { get; set; }
        public Customer customer { get; set; }
    }
}
