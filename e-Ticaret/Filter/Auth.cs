using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace e_Ticaret.Filter
{
	public class Auth : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.HttpContext.Session.Get("user") == null)
			{
				context.Result = new RedirectResult("/Login/Login");
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.Get("user") == null)
			{
				context.Result = new RedirectResult("/Login/Login");
			}
		}
	}
}
