using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using BusinessLogic;
using AdminApp.Models;

namespace AdminApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MinhHungShopContext _context;

        public OrdersController(MinhHungShopContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //var minhHungShopContext = _context.Orders.Include(o => o.Customer);
            //return View(await minhHungShopContext.ToListAsync());
            OrderBLL orderBLL = OrderBLL.getIns();
            List<OrderView> list =await orderBLL.Get();
            return View(list);

        }
        public async Task<IActionResult> Approved()
        {
            List<OrderView> listTrue = new List<OrderView>();
           //var minhHungShopContext = _context.Orders.Include(o => o.Customer);
           //return View(await minhHungShopContext.ToListAsync());
           OrderBLL orderBLL = OrderBLL.getIns();
            List<OrderView> list = await orderBLL.Get();
            foreach(OrderView orderView in list)
            {
                if(orderView.Status==true)
                {
                    listTrue.Add(orderView);
                }
            }
            return View("Index",listTrue);

        }
        public async Task<IActionResult> NonApproval()
        {
            List<OrderView> listFalse = new List<OrderView>();
            OrderBLL orderBLL = OrderBLL.getIns();
            List<OrderView> list = await orderBLL.Get();
            foreach (OrderView orderView in list)
            {
                if (orderView.Status != true)
                {
                    listFalse.Add(orderView);
                }
            }
            return View("Index", listFalse);

        }
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OrderDetailModel orderDetailModel = new OrderDetailModel();
            //var orders = await _context.Orders
            //    .Include(o => o.Customer)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (orders == null)
            //{
            //    return NotFound();
            //}
            OrderBLL orderBLL = OrderBLL.getIns();
            List<Product> products =await orderBLL.GetOrderDetail(id);
            orderDetailModel.products = products;
            List<OrderView> listOrderView = await orderBLL.Get();
            foreach(OrderView orderView in listOrderView)
            {
                if(orderView.OrderId==id)
                {
                    orderDetailModel.orderView = orderView;
                }
            }
            return View(orderDetailModel);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,CustomerId,ModifiedBy,CreatedDate,CreatedBy,ModifiedDate,Status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orders.CustomerId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orders.CustomerId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OrderDate,CustomerId,ModifiedBy,CreatedDate,CreatedBy,ModifiedDate,Status")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orders.CustomerId);
            return View(orders);
        }

        //GET: Orders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OrderBLL orderBLL = OrderBLL.getIns();
            await orderBLL.Remove(id);
            //var orders = await _context.Orders.FindAsync(id);
            //_context.Orders.Remove(orders);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Approval(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OrderBLL orderBLL = OrderBLL.getIns();
            await orderBLL.UpdateStatus(id);
            //var orders = await _context.Orders.FindAsync(id);
            //_context.Orders.Remove(orders);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { @id = id });
        }
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
