using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Areas.Admin.ViewsModel;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    [Authorize(Roles = "Ogretmen")]
    public class OgretmenController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OgretmenController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
			var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);

                ViewBag.ogrenci_sayım = _context.Ogrenciler.Where(x => x.BolumId == ogretmen.BolumId).Count();
                ViewBag.ders_sayım = _context.Dersler.Where(x => x.BolumId == ogretmen.BolumId).Count();
				ViewBag.not_girilen_ders_sayısı = _context.Notlar
	                .Where(x => x.OgretmensId == ogretmen.Id &&
				                (x.NotOdev.HasValue || x.NotVize.HasValue || x.NotFinal.HasValue))
	                .Select(x => (x.NotOdev.HasValue ? 1 : 0) + (x.NotVize.HasValue ? 1 : 0) + (x.NotFinal.HasValue ? 1 : 0))
	                .Sum();
				var ogrenciNotlar = _context.Notlar
					.Where(x => x.OgretmensId == ogretmen.Id &&
				(x.NotOdev.HasValue || x.NotVize.HasValue || x.NotFinal.HasValue));

				List<double> ortalamaNotlar = new List<double>();
				foreach (var not in ogrenciNotlar)
				{
					double toplamNot = 0;
					int notSayisi = 0;

					if (not.NotOdev.HasValue)
					{
						toplamNot += not.NotOdev.Value;
						notSayisi++;
					}
					if (not.NotVize.HasValue)
					{
						toplamNot += not.NotVize.Value;
						notSayisi++;
					}
					if (not.NotFinal.HasValue)
					{
						toplamNot += not.NotFinal.Value;
						notSayisi++;
					}

					if (notSayisi > 0)
					{
						double ortalama = toplamNot / notSayisi;
						ortalamaNotlar.Add(ortalama);
					}
				}

				double ortalamaNot = ortalamaNotlar.Any() ? ortalamaNotlar.Average() : 0;
				ViewBag.ortalama_not = Math.Round(ortalamaNot,2);

                // Ders Programım
                ViewBag.derslerim = await _context.Dersler
					.Where(x => x.OgretmensId == ogretmen.Id)
					.OrderBy(x => x.DersGün == "Pazartesi" ? 1 :
								  x.DersGün == "Salı" ? 2 :
								  x.DersGün == "Çarşamba" ? 3 :
								  x.DersGün == "Perşembe" ? 4 :
								  x.DersGün == "Cuma" ? 5 : 6) // Diğer günler için aynı sıralamaya ekleyebilirsiniz
					.ToListAsync();

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


			}

			return View();
        }


		[HttpPost]
		public IActionResult DersBasarisi()
		{
			var dersler = _context.Dersler.ToList(); // Tüm dersleri al

			var dersBasarilari = new List<object>();

			foreach (var ders in dersler)
			{
				var dersNotlari = _context.Notlar
					.Where(n => n.DersId == ders.Id &&
								(n.NotOdev.HasValue || n.NotVize.HasValue || n.NotFinal.HasValue))
					.ToList();

				var gecenOgrenciSayisi = 0;
				var kalanOgrenciSayisi = 0;

				foreach (var not in dersNotlari)
				{

					decimal toplamNot = 0;
					decimal toplamAgirlik = 0;

					if (not.NotOdev.HasValue)
					{
						toplamNot += not.NotOdev.Value * 0.25m;
						toplamAgirlik += 0.25m;
					}

					if (not.NotVize.HasValue)
					{
						toplamNot += not.NotVize.Value * 0.35m;
						toplamAgirlik += 0.35m;
					}

					if (not.NotFinal.HasValue)
					{
						toplamNot += not.NotFinal.Value * 0.40m;
						toplamAgirlik += 0.40m;
					}

					decimal ortalama = toplamAgirlik != 0 ? toplamNot / toplamAgirlik : 0;
					ortalama = Math.Round(ortalama, 2); // Ondalık basamakları 2'ye yuvarla

					if (ortalama >= 50)
						gecenOgrenciSayisi++;
					else
						kalanOgrenciSayisi++;
				}

				var dersBasarisi = new
				{
					DersAdi = ders.DersAd,
					GecenOgrenciSayisi = gecenOgrenciSayisi,
					KalanOgrenciSayisi = kalanOgrenciSayisi
				};

				dersBasarilari.Add(dersBasarisi);
			}

			return Json(dersBasarilari);
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

            var ogretmen = _context.Ogretmenler
                .Include(x => x.Fakulte)
                .Include(x => x.Bolum)
                .Include(x=> x.Adres)
                .Where(x => x.OgretmenEposta == users.Email);
            return View(ogretmen);
        }
    }
}
