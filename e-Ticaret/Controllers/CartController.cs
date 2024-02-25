using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Controllers
{
	public class CartController : Controller
	{
      private readonly DatabaseContext _context;

      public CartController(DatabaseContext context)
      {
         _context = context;
      }

      [Route("/add-to-cart/{productId:int}")]
      [HttpGet]
      public async Task<IActionResult> AddProduct([FromRoute] int productId)
      {
         // add 1 product...

         var prevUrl = Request.Headers.Referer.FirstOrDefault();

         if (prevUrl is null)
         {
            return RedirectToAction(nameof(Edit));
         }

         return Redirect(prevUrl);
      }

      //[HttpPost]
      //public async Task<IActionResult> AddProduct(/*usercart*/)
      //{
      //	return View();
      //}


      [Route("/cart")]
      [HttpGet]
		public async Task<IActionResult> Edit ()
		{
			return View();
		}


      //[Route("/cart")]
      //[HttpPost]
      //public async Task<IActionResult> Edit(/*usercart*/)
      //{
      //	return View();
      //}
   }
}
