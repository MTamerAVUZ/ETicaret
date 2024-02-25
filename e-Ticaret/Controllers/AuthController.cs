using App.Data.Context;
using App.Data.Entities;
using e_Ticaret.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace e_Ticaret.Controllers
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
		public async Task<IActionResult> Login()
		{
			return View();
		}


		[Route("/login")]
		[HttpPost]
		public async Task<IActionResult> Login(AuthLoginModelView authLoginModelView)
		{
			try
			{
				if (authLoginModelView is null)
					return RedirectToAction(nameof(Login));
				if (!ModelState.IsValid)
					return View(authLoginModelView);

				var kullanici = await _context.Users.FirstOrDefaultAsync(t => t.Email == authLoginModelView.Email && t.Password == authLoginModelView.Password);

				if (kullanici == null)
				{
					ModelState.AddModelError(nameof(authLoginModelView.Password), "Kullanıcı Kodu veya Şifreniz Hatalı");
					return View(authLoginModelView);
				}				
				string userJson = JsonSerializer.Serialize<UserEntity>(kullanici);
				HttpContext.Session.SetString("user", userJson); 
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

			return RedirectToAction("Index","Home");
		}


		[Route("/register")]
		[HttpGet]
		public async Task<IActionResult> Register()
		{
			return View();
		}

		[Route("/register")]
		[HttpPost]
		public async Task<IActionResult> Register(AuthRegisterViewModel authRegisterViewModel)
		{
			if(authRegisterViewModel is null)
				return View(authRegisterViewModel);
			if(!ModelState.IsValid)
				return View(authRegisterViewModel);

			var yeniKullanici = new UserEntity
			{
				Email = authRegisterViewModel.Email,
				FirstName = authRegisterViewModel.FirstName,
				LastName = authRegisterViewModel.LastName,
				Password = authRegisterViewModel.Password,
				UserRoles = new HashSet<UserRolesEntity> { new UserRolesEntity { RoleId = 3 } }
			};

			_context.Users.Add(yeniKullanici);
			await _context.SaveChangesAsync();

			TempData["Message"] = "Kullanıcı kaydı başarıyla yapıldı.";

			return View();
		}


		[Route("/forgot-password")]
		[HttpGet]
		public async Task<IActionResult> ForgotPassword()
		{
			return View();
		}

		//[Route("/forgot-password")]
		//[HttpPost]
		//public async Task<IActionResult> ForgotPassword(/*şifremi unuttum dto gelecek*/)
		//{
		//	return View();
		//}

		[Route("/renew-password/{verificationCode}")]
		[HttpGet]
		public async Task<IActionResult> RenewPassword([FromRoute] string verificationCode)
		{
			return View();
		}

		[Route("/renew-password")]
		[HttpPost]
		public async Task<IActionResult> RenewPassword([FromForm] object changePasswordModel)
		{
			return View();
		}






		[Route("/logout")]
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			HttpContext.Session.Remove("user"); 
			HttpContext.Session.Clear();

			return RedirectToAction("Index", "Home");
		}










	}
}
