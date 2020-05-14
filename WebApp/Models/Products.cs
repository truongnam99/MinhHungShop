using BusinessLogic;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Products
    {

        public List<Product> products { get; set; }    
        public Products()
        {
            products = new List<Product>();
        }
    }
}
