using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    public class ReportController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.TopProducts = await ProductBLL.getIns().GetTop();
            ViewBag.OrderByMonth =  await OrderBLL.getIns().OrderByMonths();
            return View();  
        }
    }
}