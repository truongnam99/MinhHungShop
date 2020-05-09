using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Categories
    {
        public List<ProductCategory> categories { get; set; }
        public Categories()
        {
            categories = new List<ProductCategory>();
        }
    }
}
