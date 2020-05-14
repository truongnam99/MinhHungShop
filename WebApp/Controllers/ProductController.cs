using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(long id)
        {
            ProductBLL productBLL = ProductBLL.getIns();
            Product product = productBLL.GetProduct(id);

            return View(product);
        }
    }
}