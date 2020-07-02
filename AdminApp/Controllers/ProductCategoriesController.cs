using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using BusinessLogic;

namespace AdminApp.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly MinhHungShopContext _context;

        public ProductCategoriesController(MinhHungShopContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index(Utils.Status? status, string searchText)
        {
            ViewBag.Status = status;
            ViewBag.ProductCategories = await ProductCategoryBLL.getIns().GetProductCategories(searchText);
            ViewBag.searchText = searchText;
            return View();
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create(Utils.Status? status)
        {
            ViewBag.Status = status;
            return View(new ProductCategory());
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,MetaTitle,DisplayOrder,ShowOnHome")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                Utils.Status status = await ProductCategoryBLL.getIns().Create(productCategory);
                return RedirectToAction("Create", new { status = status });
            }
            return View();
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(long? id, Utils.Status? status)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await ProductCategoryBLL.getIns().GetProductCategory(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            ViewBag.Status = status;
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id, Name,MetaTitle,DisplayOrder,ShowOnHome")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Utils.Status status = await ProductCategoryBLL.getIns().Update(productCategory);
                ViewBag.ProductCategory = productCategory;
                return RedirectToAction("Edit", new { status = status });
            }
            ViewBag.ProductCategory = productCategory;
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await ProductCategoryBLL.getIns().GetProductCategory(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            ViewBag.ProductCategory = productCategory;

            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Utils.Status status = await ProductCategoryBLL.getIns().Delete(id);
            return RedirectToAction("Index", new { status = status});
        }

        private bool ProductCategoryExists(long id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }
    }
}
