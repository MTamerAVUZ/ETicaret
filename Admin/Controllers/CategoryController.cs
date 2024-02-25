using Admin.Models;
using Admin.Models.ViewModels;
using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DatabaseContext _context;

		public CategoryController(DatabaseContext context)
		{
			_context = context;
		}

		[Route("/categories")]
		[HttpGet]
		public async Task<IActionResult> List()
		{
			var data = await _context.Categories.ToListAsync();

			return View(data);
		}



		[Route("/categories/create")]
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[Route("/categories/create")]
		[HttpPost]
		public async Task<IActionResult> Create(CategoryCreateViewModel categoryCreateViewModel)
		{
			if (categoryCreateViewModel is null)
				return View(categoryCreateViewModel);

			if (!ModelState.IsValid)
				return View(categoryCreateViewModel);

			var category = new CategoryEntity()
			{
				Tanim = categoryCreateViewModel.Tanim,
				Name = categoryCreateViewModel.Name,
				Color = categoryCreateViewModel.Color,
				IconCssClass = categoryCreateViewModel.IconCssClass
			};
			await _context.Categories.AddAsync(category);
			await _context.SaveChangesAsync();

			return RedirectToAction("List", "Category");
		}


		[Route("/categories/{id:int}/edit")]
		[HttpGet]
		public async Task<IActionResult> Edit([FromRoute] int id)
		{
			var data = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			return View(data);
		}


		[Route("/categories/{id:int}/edit")]
		[HttpPost]
		public async Task<IActionResult> Edit(int id, CategoryEditViewModel categoryEditViewModel)
		{
			if (categoryEditViewModel is null)
				return View(categoryEditViewModel);

			if (!ModelState.IsValid)
				return View(categoryEditViewModel);

			var existingCategory = await _context.Categories.FindAsync(id);

			if (existingCategory == null)
				return NotFound();

			existingCategory.Tanim = categoryEditViewModel.Tanim;
			existingCategory.Name = categoryEditViewModel.Name;
			existingCategory.Color = categoryEditViewModel.Color;
			existingCategory.IconCssClass = categoryEditViewModel.IconCssClass;

			await _context.SaveChangesAsync();
			return RedirectToAction("List", "Category");
		}


		[Route("/categories/{id:int}/delete")]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var silinecekData = await _context.Categories.FindAsync(id);
			if (silinecekData is null)
				return NotFound();

			_context.Categories.Remove(silinecekData);
			await _context.SaveChangesAsync();

			return RedirectToAction("List", "Category");
		}

	}
}
