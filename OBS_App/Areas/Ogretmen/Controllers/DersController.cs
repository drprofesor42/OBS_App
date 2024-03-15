using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class DersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public DersController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Ogretmen_Derslerim()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(d => d.OgretmenEposta == kullanıcı.Email);
                var dersler = _context.Dersler.Include(x => x.Ogrencisler).Where(x => x.OgretmensId == ogretmen.Id).ToList();

                return View(dersler);
            }
            return View();
        }

        public IActionResult DersProgramı()
        {
            return View();
        }

    }
}
