using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminApp.Models;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UserBLL userBLL = UserBLL.getIns();
            DbSet<User> users = userBLL.GetAll();
            
            userBLL.Update(new User()
            {
                Username = "abc",
                Password = "cba",
                Name = "abc cba cde"
            });
            foreach (User user in users)
            {
                Console.Write(user.Username + ":" + user.Password);
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
