using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class FakulteController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public FakulteController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> DanısmanOgrenciler()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                // Öğretmen İsmine Göre Aramamalı
                var danisanlar = _context.Ogrenciler.Include(x => x.Bolum).Where(d => d.OgrenciDanisman == ogretmen.OgretmenAd).ToList();

                return View(danisanlar);
            }
            return View();
        }

        public async Task<IActionResult> AkademikTakvim()
        {
            var takvimler = await _context.AkademikTakvimler.ToListAsync();

            return View(takvimler);
        }


    }
}
