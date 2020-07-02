using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AdminApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MinhHungShopContext _context;
        private readonly IHostingEnvironment _env;
        public ProductsController(MinhHungShopContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        
        public async Task<IActionResult> Index([FromQuery(Name = "searchText")]String searchText)
        {
            ViewBag.Products = await ProductBLL.getIns().GetProducts(searchText);
            ViewBag.searchText = searchText;
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
        public async Task<IActionResult> Create([Bind("Name, Price,ProducerId,CategoryId,Description,Detail")]Product product, IFormFile imageUpload)
        {
            
            if (ModelState.IsValid)
            {
                string filePath = _env.WebRootPath + $@"\images\{imageUpload.FileName}";
                string dbImagePath = $@"\images\{imageUpload.FileName}";
                
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    
                    if (fileStream.Length < 2097152)
                    {
                        await imageUpload.CopyToAsync(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                    product.Image = dbImagePath;
                    Utils.Status status = await ProductBLL.getIns().Add(product);
                    return RedirectToAction("Create", new { status = status });
                }
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
        public async Task<IActionResult> Edit(long id, [Bind("Id, Name, Price,ProducerId,CategoryId,Description,Detail")] Product product, IFormFile imageUpload)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string filePath = _env.WebRootPath + $@"\images\{imageUpload.FileName}";
                string dbImagePath = $@"\images\{imageUpload.FileName}";
                string filePath2 = _env.WebRootPath.Replace("AdminApp\\wwwroot", "WebApp\\wwwroot") + $@"\images\{imageUpload.FileName}";
                using (FileStream fileStream = new FileStream(filePath2, FileMode.Create, FileAccess.Write))
                {

                    if (fileStream.Length < 2097152)
                    {
                        await imageUpload.CopyToAsync(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {

                    if (fileStream.Length < 2097152)
                    {
                        await imageUpload.CopyToAsync(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                    product.Image = dbImagePath;
                    Utils.Status status = await ProductBLL.getIns().Update(product);
                    ViewBag.Product = product;
                    return RedirectToAction("Edit", new { status = status });
                }
            }
            return RedirectToAction("Edit", new { status = Utils.Status.Failed });
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