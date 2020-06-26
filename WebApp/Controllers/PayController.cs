using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PayController : Controller
    {
        CartController controller = new CartController();

        [HttpGet]
        public IActionResult Index()
        {

            Products products = controller.GetCartProduct();
            OrderModel orderModel = new OrderModel();
            orderModel.products = products.products;
            //List<Product> list = new List<Product>();
            //list = products.products;
            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                long cusId = await CustomerBLL.getIns().Add(orderModel.customer);
                Orders orders = new Orders();
                orders.CustomerId = cusId;
                long orderId = await OrderBLL.getIns().Add(orders);
                Products products = controller.GetCartProduct();
                foreach (Product product in products.products)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = orderId;
                    orderDetail.ProductId = product.Id;
                    orderDetail.Price = product.Price;
                    orderDetail.Quantity = product.Quantity;
                    await OrderBLL.getIns().AddOrderDetail(orderDetail);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}