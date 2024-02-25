using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace e_Ticaret.Controllers
{
	public class ProfileController : Controller
	{
		private readonly DatabaseContext _context;

		public ProfileController(DatabaseContext context)
		{
			_context = context;
		}

		[Route("/profile")]
		[HttpGet]
		public async Task<IActionResult> Details()
		{
			var userName = HttpContext.Session.GetString("user");
			if (string.IsNullOrEmpty(userName))
			{
				return RedirectToAction("Login", "Auth");
			}
			var user = JsonSerializer.Deserialize<UserEntity>(userName);
			return View(user);
		}



		[Route("/profile/edit")]
		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			var userName = HttpContext.Session.GetString("user");
			if (string.IsNullOrEmpty(userName))
			{
				return RedirectToAction("Login", "Auth");
			}
			var user = JsonSerializer.Deserialize<UserEntity>(userName);
			return View(user);
		}

		//[Route("/profile/edit")]
		//[HttpPost]
		//public async Task<IActionResult> Edit()
		//{

		//}







		[Route("/my-orders")]
		[HttpGet]
		public async Task<IActionResult> MyOrders()
		{
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> MyOrders(/*orders*/)
		//{
		//	return View();
		//}
		[Route("/my-products")]
		[HttpGet]
		public async Task<IActionResult> MyProducts()
		{
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> MyProducts(/*products*/)
		//{
		//	return View();
		//}



	}
}
