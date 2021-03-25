using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinhHungShop.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("products")]
        public IActionResult Products()
        {
            return View();
        }
    }
}