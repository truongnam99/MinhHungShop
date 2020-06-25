using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public async Task<ActionResult> Index()
        {
            List<Customer> customers = await CustomerBLL.getIns().GetCustomers();
            ViewBag.customers = customers;
            return View();
        }
    }
}