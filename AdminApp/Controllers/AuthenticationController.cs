using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    public class AuthenticationController : Controller
    {
        SignInManager<IdentityUser> _signManager;
        public AuthenticationController(SignInManager<IdentityUser> signInManage)
        {
            _signManager = signInManage;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}