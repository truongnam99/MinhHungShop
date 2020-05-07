using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ListProduct
    {
        public List<Product> products { get; set; }
        public ListProduct()
        {
            products = new List<Product>();
        }
    }
}
