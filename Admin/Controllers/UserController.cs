using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
  public class UserController : Controller
  {
    private readonly DatabaseContext _context;

    public UserController(DatabaseContext context)
    {
      _context = context;
    }

    [Route("/users")]
    [HttpGet]
    public async Task<IActionResult> List()
    {
      var data = await _context.Users
    .Include(user => user.UserRoles)
    .ThenInclude(userRole => userRole.Role)
    .ToListAsync();
      return View(data);
    }

    [Route("/users/{id:int}/approve")]
    [HttpGet]
    public async Task<IActionResult> Approve(int id)
    {
      var kullanici = await _context.Users.Include(t => t.UserRoles).SingleOrDefaultAsync(t => t.Id == id);

      if (kullanici is null)      
        return NotFound();

      var saticiRolu = await _context.Roles.FirstOrDefaultAsync(t => t.Id == 2);

      if (saticiRolu is null)
        return NotFound();

			var saticiRoluVarmi = await _context.UserRoles.AnyAsync(t => t.RoleId == saticiRolu.Id && t.UserId == id);


			if (saticiRoluVarmi)
      {
        ViewBag.SaticiHatasi= "Bu kullanıcı zaten bir satıcı rolüne sahip.";
      }
      else
      {
        kullanici.UserRoles.Add(new UserRolesEntity { RoleId = saticiRolu.Id });
        await _context.SaveChangesAsync();
      }

     
      return RedirectToAction(nameof(List));
    }

    //[HttpPost]
    //public async Task<IActionResult> Approve(/*user satıcı onay dto*/)
    //{
    //	return View();
    //}


  }
}
