using App.Data.Context;
using App.Data.Entities;
using e_Ticaret.Models;
using e_Ticaret.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace e_Ticaret.Controllers
{
	public class HomeController : Controller
	{
      private readonly DatabaseContext _context;

      public HomeController(DatabaseContext context)
      {
         _context = context;
      }
     

		

		public async Task<IActionResult> Index()
		{
			return View();
		}


      [Route("/about-us")]
      [HttpGet]
      public async Task<IActionResult> AboutUs()
		{
			return View();
		}


      [Route("/contact")]
      [HttpGet]
      public async Task<IActionResult> Contact()
		{
			return View();
		}

      [Route("/contact")]
      [HttpPost]
      public async Task<IActionResult> Contact([FromForm] HomeContactViewModel newContactMessageModel)
      {
      if (newContactMessageModel == null)
        return View(newContactMessageModel);
      if(!ModelState.IsValid)
        return View(newContactMessageModel);

      var message = new ContactEntity()
      {
        IssuerMail = newContactMessageModel.IssuerMail,
        Issuer = newContactMessageModel.Issuer,
        IssuerMessage = newContactMessageModel.IssuerMessage,
      };

      _context.Messages.Add(message);
      await _context.SaveChangesAsync();
         return RedirectToAction("Index","Home");
      }



      [Route("/product/list")]
      [HttpGet]
      public async Task<IActionResult> Listing()
		{
      var data = await _context.Products.Include(p => p.User)
        .Include(p => p.Category)
        .ToListAsync();
      return View(data);
    }

      [Route("/product/{id:int}/details")]
      [HttpGet]
      public async Task<IActionResult> ProductDetail([FromRoute] int id)
      {
        var data=await _context.Products.FindAsync(id);
         return View(data);
      }

     
	}
}
