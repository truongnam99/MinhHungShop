using BusinessLogic;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ListProAndCate
    {

        public List<Product> products { get; set; }
        public List<ProductCategory> categories { get; set; }
      
        public ListProAndCate()
        {

            categories = new List<ProductCategory>();
            products = new List<Product>();
        }
    }
}
