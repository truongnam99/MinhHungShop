using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class GocTuVanController : Controller
    {
        public IActionResult NhaTuoiMoi()
        {
            return View();
        }
        public IActionResult SonNhaTietKiem()
        {
            return View();
        }
        public IActionResult NguyenTacSonNha()
        {
            return View();
        }
        public IActionResult ToiUuChiPhi()
        {
            return View();
        }
        public IActionResult KhacPhucVetXuoc()
        {
            return View();
        }
    }
}