using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
  public class CommentController : Controller
  {
    private readonly DatabaseContext _context;

    public CommentController(DatabaseContext context)
    {
      _context = context;
    }

    [Route("/comment")]
    [HttpGet]
    public async Task<IActionResult> List()
    {
      ViewBag.Kategoriler = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
           
      return View();
    }

    [Route("/comment/{id:int}/products")]
    [HttpPost]
    public async Task<IActionResult> UrunGetir(int id)
    {
      var products = await _context.Products
        .Where(p => p.CategoryId == id)
        .ToListAsync();

      return Json(products);
    }
    [Route("/comment/{id:int}/comments")]
    [HttpPost]
    public async Task<IActionResult> YorumGetir(int id)
    {
      var yorumlar = await _context.ProductComments.Where(p => p.ProductId == id)
        .Include(p=>p.User)
        .ToListAsync();

      //var data = await _context.Products.Include(p => p.User)
      //  .Include(p => p.Category)
      //  .ToListAsync();
      return Json(yorumlar);
    }



    [Route("/comment/{id:int}/approve")]
    [HttpPost]
    public async Task<IActionResult> Approve(int id)
    {
      var comment = await _context.ProductComments.FindAsync(id);

      if(comment is null)
        return NotFound();

      comment.IsConfirmed = true;
      await _context.SaveChangesAsync();

      return RedirectToAction("List","Comment");
    }

		[Route("/comment/{id:int}/delete")]
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{		
			var silinecek = await _context.ProductComments.FindAsync(id);
			if (silinecek == null)
			{
				return NotFound();
			}

			_context.ProductComments.Remove(silinecek);
			await _context.SaveChangesAsync();

			return Ok(); 
		}	
	}
}


