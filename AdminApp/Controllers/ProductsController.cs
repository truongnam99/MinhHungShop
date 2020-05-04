using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MinhHungShopContext _context;
        public ProductsController(MinhHungShopContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewBag.Products = await ProductBLL.getIns().GetProducts();
            return View();
        }

        public async Task<IActionResult> Add(Utils.Status? status)
        {
            ViewBag.Status = status;
            return View(new Product());
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Name, Price,ProducerId,CategoryId,Image,Description,Detail")]Product product)
        {
            if (ModelState.IsValid)
            {
                Utils.Status status = await ProductBLL.getIns().Add(product);
                return RedirectToAction("Add", new { status = status });
            }
            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }
        
        public IActionResult Delete(long id)
        {
            ViewBag.Product = ProductBLL.getIns().GetProduct(id);
            return View();
        }
        
        public IActionResult Search()
        {
            return View();
        }
    }
}