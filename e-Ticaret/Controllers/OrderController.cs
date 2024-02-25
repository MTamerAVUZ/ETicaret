using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Controllers
{
	public class OrderController : Controller
	{
      private readonly DatabaseContext _context;

      public OrderController(DatabaseContext context)
      {
         _context = context;
      }


      [HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

      //[HttpPost]
      //public async Task<IActionResult> Create(/*order*/)
      //{
      //	return View();
      //}

      [Route("/order/{orderId:int}/details")]
      [HttpGet]
      public async Task<IActionResult> Details([FromRoute] int orderId)
      {
         return View();
      }





   }
}
