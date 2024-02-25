using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
	public class ProductController : Controller
	{
      private readonly DatabaseContext _context;

      public ProductController(DatabaseContext context)
      {
         _context = context;
      }


      [Route("/products/")]
      [HttpGet]
      public async Task<IActionResult> List()
      {
      var data= await _context.Products.Include(p => p.User)
        .Include(p=>p.Category)
        .ToListAsync();
         return View(data);
      }
    

		[Route("/products/filter")]
      [HttpGet]
      public async Task<IActionResult> Filter([FromQuery] object filterOptions)
      {
         // will return filtered products as json
         return Json(new { });
      }

      [Route("/products/{id:int}/delete")]
      [HttpGet]
      public async Task<IActionResult> Delete([FromRoute] int id)
      {
      var silinecek= await _context.Products.FindAsync(id);
      if (silinecek is null)      
        return NotFound();

       _context.Products.Remove(silinecek);
      await _context.SaveChangesAsync();

         return RedirectToAction(nameof(List));
      }
   }
}
