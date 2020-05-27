using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

        public async Task<IActionResult> Details(long? id)
        {

            var product = ProductBLL.getIns().GetProduct(id);
            return View(product);
        }

        public async Task<IActionResult> Create(Utils.Status? status)
        {
            ViewBag.Status = status;
            ViewBag.Producers = await ProducerBLL.getIns().GetProducers();
            ViewBag.ProductCategories = await ProductCategoryBLL.getIns().GetProductCategories();

            return View(new Product());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Price,ProducerId,CategoryId,Description,Detail")]Product product)
        {
            //if (file.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(file.FileName);
            //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //    file.SaveAs(path);
            //}


            if (ModelState.IsValid)
            {
                Utils.Status status = await ProductBLL.getIns().Add(product);
                return RedirectToAction("Create", new { status = status });
            }
            else
            {
                ViewBag.Producers = await ProducerBLL.getIns().GetProducers();
                ViewBag.ProductCategories = await ProductCategoryBLL.getIns().GetProductCategories();
                ViewBag.Status = Utils.Status.Failed;
                return View();
            }
        }

        public async Task<IActionResult> Edit(long? id, Utils.Status? status)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = ProductBLL.getIns().GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Producers = await ProducerBLL.getIns().GetProducers();
            ViewBag.ProductCategories = await ProductCategoryBLL.getIns().GetProductCategories();
            ViewBag.Status = status;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id, Name, Price,ProducerId,CategoryId,Image,Description,Detail")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Utils.Status status = await ProductBLL.getIns().Update(product);
                ViewBag.Product = product;
                return RedirectToAction("Edit", new { status = status });
            }
            ViewBag.Producer = product;
            return View(product);
        }

        public IActionResult Delete(long id)
        {
            ViewBag.Product = ProductBLL.getIns().GetProduct(id);
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Utils.Status status = await ProductBLL.getIns().Remove(id);
            return RedirectToAction("Index", new { status = status });
        }

        

        public IActionResult Search()
        {
            return View();
        }
    }
}