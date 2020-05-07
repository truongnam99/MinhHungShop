using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Product pr = new Product();
            //pr.Name = "son tuong";
            //pr.CategoryId = 02;
            //pr.Description = "đẹp";
            //pr.Price = 200;
            ProductBLL productBLL = ProductBLL.getIns();
            //var mytask = productBLL.Add(pr);
            List<Product> products = await productBLL.GetTop();
            List<ProductCategory> categories = await productBLL.GetCategory();
            ListProAndCate list = new ListProAndCate();
            list.products = products;
            list.categories = categories;
            //foreach (Product pro in products)
            //{
            //    list.products.Add(pro);
            //}
            //foreach (ProductCategory cate in categories)
            //{
            //    list.categories.Add(cate);
            //}
            // list.products.Add(pr);
            return View(list);
        }
        
        public async Task<IActionResult> Category(long id)
        {
            ProductBLL productBLL = ProductBLL.getIns();
            List<Product> products = await productBLL.GetProductByCategory(id);
            List<ProductCategory> categories = await productBLL.GetCategory();
            ListProAndCate list = new ListProAndCate();
            list.products = products;
            list.categories = categories;
            return View(list);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
