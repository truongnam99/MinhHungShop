using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    
    public class CartController : Controller
    {


        static ProductBLL productBLL = ProductBLL.getIns();
        static Products products = new Products();
        static bool update = false;
        static string idPro = "";
        static List<long> ids = new List<long>();
        public IActionResult Index()
        {
            string input =Request.Cookies["id"];

            string[] arr = input.Split('-');
            
            if (update == false)
            {

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (!ids.Contains(Convert.ToInt64(arr[i])))
                    {
                        ids.Add(Convert.ToInt64(arr[i]));
                        products.products.Add(productBLL.GetProduct(Convert.ToInt64(arr[i])));
                    }
                }
            }
            return View(products);

        }
        public IActionResult GetProduct(long id)
        {

            
            idPro += id.ToString()+"-";
            Response.Cookies.Append("id", idPro);
            update = false;
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Update(Products pros, int id)
        {
            products.products[id].Quantity = pros.products[id].Quantity;
            pros = products;
            update = true;
            return RedirectToAction("Index", "Cart");
        }
    }
}