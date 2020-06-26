using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderModel
    {
        public List<Product> products { get; set; }
        public Customer customer { get; set; }
        public OrderModel()
        {
            products = new List<Product>();
            //customer = new Customer();
        }
       
    }
}
