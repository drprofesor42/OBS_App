using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class DersIslemController : Controller
    {       
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DersIslemController(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Derslerim()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                // Kullanıcının derslerini çek
                var ogretmen = _context.Ogretmenler.FirstOrDefault(d => d.OgretmenEposta == kullanıcı.Email);
                var dersler = _context.Dersler.Where(x => x.profesorId == ogretmen.Id).ToList();

                return View(dersler);
            }

            // Hata Gönder
            return View();
        }

        public IActionResult DersProgramı()
        {
            return View();
        }

        public IActionResult DersTalepleri()
        {
            return View();
        }
    }
}
