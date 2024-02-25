using App.Data.Context;
using App.Data.Entities;
using e_Ticaret.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Controllers
{
	public class ProductController : Controller
	{
		private readonly DatabaseContext _context;

		public ProductController(DatabaseContext context)
		{
			_context = context;
		}


		[Route("/product")]
		[HttpGet]
		public async Task<IActionResult> Create()
		{

			ViewBag.Satıcılar = new SelectList(await _context.Users
					 .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller")) 
					 .Select(u => new { Id = u.Id, FullName = u.UserFullName })
					 .ToListAsync(),
					 "Id", "FullName");

			ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");

			return View();
		}

		[Route("/product")]
		[HttpPost]
		public async Task<IActionResult> Create([FromForm] ProductCreateViewModel productCreateViewModel)
		{
			if (productCreateViewModel is null)
			{
        ViewBag.Satıcılar = new SelectList(await _context.Users
           .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller"))
           .Select(u => new { Id = u.Id, FullName = u.UserFullName })
           .ToListAsync(),
           "Id", "FullName");

        ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        return View(productCreateViewModel);
			}

			var seller = _context.Users.FindAsync(productCreateViewModel.SellerId);
			var kategori = _context.Categories.FindAsync(productCreateViewModel.CategoryId);



			if (!ModelState.IsValid)
			{
        ViewBag.Satıcılar = new SelectList(await _context.Users
           .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller"))
           .Select(u => new { Id = u.Id, FullName = u.UserFullName })
           .ToListAsync(),
           "Id", "FullName");

        ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        return View(productCreateViewModel);
			}

			var yeni = new ProductEntity()
			{
				//User=productCreateViewModel.User,
				//Category=productCreateViewModel.Category,
				Name = productCreateViewModel.Name,
				Price = productCreateViewModel.Price,
				CategoryId = productCreateViewModel.CategoryId,
				SellerId = productCreateViewModel.SellerId,
				Details = productCreateViewModel.Details,
				StockAmount = productCreateViewModel.StockAmount
			};

			_context.Products.Add(yeni);
			await _context.SaveChangesAsync();


			return RedirectToAction("Listing", "Home");
		}


		[Route("/product/{id:int}/edit")]
		[HttpGet]
		public async Task<IActionResult> Edit([FromRoute] int id)
		{
			var data = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
			if (data == null)
				return NotFound();
      ViewBag.Satıcılar = new SelectList(await _context.Users
           .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller"))
           .Select(u => new { Id = u.Id, FullName = u.UserFullName })
           .ToListAsync(),
           "Id", "FullName");

      ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");

      return View(data);
		}



		[Route("/product/{id:int}/edit")]
		[HttpPost]
		public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] ProductEditViewModel editProductModel)
		{
			if (editProductModel == null)
			{
        ViewBag.Satıcılar = new SelectList(await _context.Users
           .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller"))
           .Select(u => new { Id = u.Id, FullName = u.UserFullName })
           .ToListAsync(),
           "Id", "FullName");

        ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        return View(editProductModel);
			}

			if (!ModelState.IsValid)
			{
        ViewBag.Satıcılar = new SelectList(await _context.Users
           .Where(u => u.Enabled && u.UserRoles.Any(ur => ur.Role.Name == "Seller"))
           .Select(u => new { Id = u.Id, FullName = u.UserFullName })
           .ToListAsync(),
           "Id", "FullName");

        ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        return View(editProductModel);
			}

			var degisecek = await _context.Products.FindAsync(id);
			if (degisecek == null)
				return NotFound();

			
			degisecek.CategoryId = editProductModel.CategoryId;
			degisecek.SellerId = editProductModel.SellerId;
			degisecek.Price = editProductModel.Price;
			degisecek.Details = editProductModel.Details;
			degisecek.Name = editProductModel.Name;
			degisecek.StockAmount = editProductModel.StockAmount;
			degisecek.Enabled = editProductModel.Enabled;

			try
			{
				await _context.SaveChangesAsync(); 
			}
			catch (Exception ex)
			{
				return View(ex.Message);
			}

			return RedirectToAction("Listing", "Home");
		}



		[Route("/product/{id:int}/delete")]
		[HttpGet]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var silinecek = await _context.Products.FindAsync(id);
			if (silinecek is null)
				return NotFound();
			_context.Products.Remove(silinecek);
			await _context.SaveChangesAsync();

			return RedirectToAction("Listing", "Home");
		}


		[Route("/product/{id:int}/comment")]
		[HttpGet]
		public async Task<IActionResult> Comment(int id)
		{    
      var urun = await _context.Products
        .Include(p => p.User)
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);

			if(urun is null)
				return NotFound();

      var comment = await _context.ProductComments
				.Where(p=>p.ProductId==id&&p.IsConfirmed)
				.ToListAsync();
			var viewModel = new ProductCommentViewModel
      {
				Product = urun,
				 Comments = comment
			};
			return View(viewModel);
		}

		[Route("/product/{id:int}/comment")]
		[HttpPost]
		public async Task<IActionResult> Comment([FromRoute] int id, [FromForm] ProductCommentCreateModelView newProductCommentModel)
		{
			if (newProductCommentModel == null)
			{
				return BadRequest("Yorum Bilgileri Eksik.");
			}
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound("Ürün bulunamadı.");
			}			
			var newComment = new ProductCommentEntity
			{
				ProductId = id,
				UserId =1, //userId yi alabildiğim zaman düzenlenecek!!!
				Text = newProductCommentModel.Text, 
				StarCount = newProductCommentModel.StarCount, 
				IsConfirmed = false 
			};

			// Add the new comment to the database
			_context.ProductComments.Add(newComment);
			await _context.SaveChangesAsync();

			return RedirectToAction("Listing","Home");
		}

















	}
}
