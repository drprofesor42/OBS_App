using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class DersController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public DersController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
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

        public async Task<IActionResult> DersProgramı()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(d => d.OgretmenEposta == kullanıcı.Email);
                var dersler = _context.Dersler
                    .Include(x => x.Fakulte)
                    .Include(x => x.Bolum)
					.OrderBy(x => x.DersGün == "Pazartesi" ? 1 :
								  x.DersGün == "Salı" ? 2 :
								  x.DersGün == "Çarşamba" ? 3 :
								  x.DersGün == "Perşembe" ? 4 :
								  x.DersGün == "Cuma" ? 5 : 6)
					.Where(x => x.OgretmensId == ogretmen.Id)
                    .ToList();

                return View(dersler);
			}
			return View();
        }

    }
}
