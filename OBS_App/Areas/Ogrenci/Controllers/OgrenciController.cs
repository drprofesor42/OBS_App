using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBS_App.Areas.Admin.ViewsModel;
using OBS_App.Data;
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

					// Son 4 duyuruyu alıyoruz
					var duyurular = await _context.Duyurular.Include(x => x.Ogretmens).OrderByDescending(x => x.Id).Take(4).ToListAsync();
					if (duyurular.Count() != 0)
					{
						ViewBag.duyurular = duyurular;
					}
					else
					{
						ViewBag.duyurular = null;
					}

					// Son 5 Akademik Takvim verileri
					ViewBag.takvim = _context.AkademikTakvimler.OrderByDescending(x => x.Id).Take(5).ToList();
					ViewBag.ders_sayısı = _context.Dersler.Where(x => x.BolumId == ogrenci.BolumId).Count();

					// En yüksek en düşük ortalama
					var ogrenciNotlar = _context.Notlar.Include(not => not.Ders)
													.Where(not => not.OgrencisId == ogrenci.Id)
													.ToList();

					decimal enYuksekOrtalama = decimal.MinValue;
					decimal enDusukOrtalama = decimal.MaxValue;

					decimal toplamNot = 0;
					decimal genelOrtalama = 0;
					decimal genelAgirlik = 0;


					// Her bir not için dönerek en yüksek ve en düşük ortalama notları bul
					foreach (var not in ogrenciNotlar)
					{
						// Notları ağırlıklı olarak topla, ancak null kontrolü yap
						if (not.NotOdev.HasValue && not.NotVize.HasValue && not.NotFinal.HasValue)
						{
							decimal notOrtalamasi = 0m;
							decimal toplamAgirlik = 0m;

							if (not.NotOdev.HasValue)
							{
								notOrtalamasi += not.NotOdev.Value * 0.25m;
								toplamAgirlik += 0.25m;
							}

							if (not.NotVize.HasValue)
							{
								notOrtalamasi += not.NotVize.Value * 0.35m;
								toplamAgirlik += 0.35m;
							}

							if (not.NotFinal.HasValue)
							{
								notOrtalamasi += not.NotFinal.Value * 0.40m;
								toplamAgirlik += 0.40m;
							}

							if (toplamAgirlik > 0)
							{
								notOrtalamasi /= toplamAgirlik;
							}

							// En yüksek ve en düşük ortalama notları güncelle
							enYuksekOrtalama = Math.Max(enYuksekOrtalama, notOrtalamasi);
							enDusukOrtalama = Math.Min(enDusukOrtalama, notOrtalamasi);

							// Toplam not ve ağırlığı güncelle
							toplamNot += notOrtalamasi;
							genelAgirlik += 1; // Her bir notun ağırlığı 1 olarak kabul ediliyor

							// Genel dönem ortalama notu hesapla
							genelOrtalama = genelAgirlik != 0 ? toplamNot / genelAgirlik : 0;
						}
					}
					if (ogrenciNotlar.Count() == 0)
					{
						ViewBag.dönem_ortalama = "Sınav Yok!";
						ViewBag.sınav_yüksek_ortalama = "Sınav Yok!";
						ViewBag.sınav_düsük_ortalama = "Sınav Yok!";
					}
					else if (genelOrtalama != 0)
					{
						ViewBag.dönem_ortalama = genelOrtalama;
						ViewBag.sınav_yüksek_ortalama = enYuksekOrtalama;
						ViewBag.sınav_düsük_ortalama = enDusukOrtalama;
					}
					else
					{
						ViewBag.dönem_ortalama = "Biten Sınav Yok!";
						ViewBag.sınav_yüksek_ortalama = "Biten Sınav Yok!";
						ViewBag.sınav_düsük_ortalama = "Biten Sınav Yok!";
					}

					return View(danisman);
				}
			}
			// Hata Gönder
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Chart()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				var student = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == user.Email);

				var studentGrades = _context.Notlar
					.Include(not => not.Ders)
					.Where(not => not.OgrencisId == student.Id)
					.ToList();

				var averageGrades = studentGrades
					.Where(not => not.NotOdev.HasValue && not.NotVize.HasValue && not.NotFinal.HasValue)
					.Select(not => new
					{
						DersAd = not.Ders.DersAd,
						Ortalama = (not.NotOdev.Value * 0.25m) + (not.NotVize.Value * 0.35m) + (not.NotFinal.Value * 0.40m)
					})
					.ToList();

				var dersler = averageGrades.Select(g => g.DersAd).ToList();
				var ortalamaNotlar = averageGrades.Select(g => g.Ortalama).ToList();

				return Json(new { dersler, ortalamaNotlar });
			}

			return Json(new { error = "Kullanıcı bulunamadı." });
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
