using Admin.Filter;
using App.Admin.Models.ViewModels;
using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class AuthController : Controller
    {
      private readonly DatabaseContext _context;

      public AuthController(DatabaseContext context)
      {
         _context = context;
      }
      [Route("/login")]
        [HttpGet]
        public async Task<IActionResult>  Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginModel)
        {
            return View();
        }

    
        [Route("/logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // logout kodları...

            return RedirectToAction(nameof(Login));
        }
    }
}