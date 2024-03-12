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
				var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.Eposta == kullanıcı.Email);
				var danisman = _context.Ogretmenler.FirstOrDefault(x => x.Id == ogrenci.ogrenciDanisman);

				return View(danisman);
			}

			// Hata Gönder
			return View();
        }

		public IActionResult DanismanMesaj()
		{
			return View();
		}

		public IActionResult AkademikTakvim()
        {
            return View();
        }

        public IActionResult Duyurular()
        {
			var duyurular = _context.Duyurular.ToList();
			return View(duyurular);

        }

        public IActionResult Ayarlar()
        {
            return View();
        }

    }
}
