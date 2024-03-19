using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    [Authorize(Roles = "Ogrenci")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OgrenciController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                // Kullanıcının Danışman Bilgilerini çek
                var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
                if (ogrenci != null)
                {
                    var danisman = _context.Ogretmenler.Include(x => x.Adres).FirstOrDefault(x => x.OgretmenAd == ogrenci.OgrenciDanisman);

                    return View(danisman);
                }

            }

            // Hata Gönder
            return View();
        }

        public IActionResult DanismanMesaj()
        {
            return View();
        }

        public async Task<IActionResult> AkademikTakvim()
        {
            var takvimler = await _context.AkademikTakvimler.ToListAsync();

            return View(takvimler);
        }

        public IActionResult Duyurular()
        {
            var duyurular = _context.Duyurular.ToList();
            return View(duyurular);

        }
        public IActionResult SifreDegistir()
        {
            return View();
        }
        public IActionResult Profilim()
        {
            return View();
        }
    }
}
