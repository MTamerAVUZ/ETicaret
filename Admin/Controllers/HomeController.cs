using Admin.Models;
using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

	}
}
