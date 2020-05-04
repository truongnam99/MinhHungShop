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
    public class ProducersController : Controller
    {
        private readonly MinhHungShopContext _context;

        public ProducersController(MinhHungShopContext context)
        {
            _context = context;
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            ViewBag.Producers = await ProducerBLL.getIns().GetProducers();
            return View();
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producer = await _context.Producer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Producer == null)
            {
                return NotFound();
            }

            return View(Producer);
        }

        // GET: Producer/Create
        public IActionResult Create(Utils.Status? status)
        {
            ViewBag.Status = status;
            return View(new Producer());
        }

        // POST: Producer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Producer Producer)
        {
            if (ModelState.IsValid)
            {
                Utils.Status status = await ProducerBLL.getIns().Create(Producer);
                return RedirectToAction("Create", new { status = status });
            }
            return View();
        }

        // GET: Producer/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producer = await ProducerBLL.getIns().GetProducer(id);
            if (Producer == null)
            {
                return NotFound();
            }
            return View(Producer);
        }

        // POST: Producer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id, Name, Description")] Producer Producer)
        {
            if (id != Producer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Utils.Status status = await ProducerBLL.getIns().Update(Producer);
                ViewBag.Producer = Producer;
                return RedirectToAction("Edit", new { status = status });
            }
            ViewBag.Producer = Producer;
            return View(Producer);
        }

        // GET: Producer/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producer = await ProducerBLL.getIns().GetProducer(id);
            if (Producer == null)
            {
                return NotFound();
            }

            return View(Producer);
        }

        // POST: Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await ProducerBLL.getIns().Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(long id)
        {
            return _context.Producer.Any(e => e.Id == id);
        }
    }
}
