using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PayController : Controller
    {
        
        
        public IActionResult Index()
        {
            CartController controller = new CartController();
            Products products = controller.GetCartProduct();
            List<Product> list = new List<Product>();
            list = products.products;
            return View(list);
        }

        public IActionResult AddOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                OrderModel 
            }
        }
    }
}