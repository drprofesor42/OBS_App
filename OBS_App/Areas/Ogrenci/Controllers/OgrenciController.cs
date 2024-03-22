using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBS_App.Areas.Admin.ViewsModel;
using OBS_App.Models;

namespace OBS_App.Areas.Ogrenci.Controllers
{
	[Area("Ogrenci")]
	[Authorize(Roles = "Ogrenci")]
	public class OgrenciController : BaseController
    {
		private readonly IdentityDataContext _context;
		private readonly UserManager<AppUser> _userManager;

		public OgrenciController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
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
					var danisman = _context.Ogretmenler.Include(x => x.Bolum).FirstOrDefault(x => x.OgretmenAd + " " + x.OgretmenSoyad == ogrenci.OgrenciDanisman);

					return View(danisman);
				}
			}

			// Hata Gönder
			return View();
		}

		public async Task<IActionResult> Danisman()
		{
			var kullanıcı = await _userManager.GetUserAsync(User);
			if (kullanıcı != null)
			{
				// Kullanıcının Danışman Bilgilerini çek
				var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
				if (ogrenci != null)
				{
					var danisman = _context.Ogretmenler.Include(x => x.Adres).FirstOrDefault(x => x.OgretmenAd + " " + x.OgretmenSoyad == ogrenci.OgrenciDanisman);

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
			var duyurular = _context.Duyurular.Include(x => x.Ogretmens).ToList();
			return View(duyurular);

		}
		public IActionResult SifreDegistir()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SifreDegistir(SifreDegistirViewsModel model)
		{
			if (ModelState.IsValid)
			{
				var users = await _userManager.GetUserAsync(User);
				var token = await _userManager.GeneratePasswordResetTokenAsync(users);
				if (users != null)
				{
					await _userManager.ResetPasswordAsync(users, token, model.Parola);
					TempData["success"] = "Şifre başarıyla değiştirildi!";

					return RedirectToAction("Index");

				}
			}
			return View(model);
		}

		public async Task<IActionResult> Profilim()
		{

			var users = await _userManager.GetUserAsync(User);
			var ogrenci = _context.Ogrenciler
				.Include(x => x.Fakulte)
				.Include(x => x.Bolum)
				.Include(x => x.Adres)
				.Where(x => x.OgrenciEposta == users.Email);
			return View(ogrenci);
		}
	}
}
