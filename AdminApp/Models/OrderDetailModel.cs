using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class OrderDetailModel
    {
        public OrderView orderView { get; set; }
        public List<Product> products { get; set; }
        public OrderDetailModel()
        {
            products = new List<Product>();
        }
    }
}
