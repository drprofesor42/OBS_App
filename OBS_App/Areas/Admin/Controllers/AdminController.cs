using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IdentityDataContext _context;

        public AdminController(IdentityDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Sayaçlar
            ViewBag.ogrenci_sayısı = _context.Ogrenciler.Count();
			ViewBag.ogretmen_sayısı = _context.Ogretmenler.Count();
			ViewBag.bolum_sayısı = _context.Bolumler.Count();
			ViewBag.fakulte_sayısı = _context.Fakulteler.Count();

            // Son 4 duyuruyu alıyoruz
			var duyurular = await _context.Duyurular.Include(x => x.Ogretmens).OrderByDescending(x => x.Id).Take(4).ToListAsync();
            if (duyurular.Count() != 0 )
            {
			    ViewBag.duyurular = duyurular;
            }
            else
            {
                ViewBag.duyurular = null;
			}

            // Son 5 Akademik Takvim verileri
            ViewBag.takvim = _context.AkademikTakvimler.OrderByDescending(x => x.Id).Take(5).ToList();

			return View();
        }

		[HttpPost]
		public IActionResult Data()
		{
            // Bar
			int[] maleData = { _context.Ogrenciler.Where(x => x.OgrenciCinsiyet == "Erkek").Count() }; 
			int[] femaleData = { _context.Ogrenciler.Where(x => x.OgrenciCinsiyet == "Kız").Count() };

            // S-Bar
            // Bölümlere göre öğrenci sayılarını al, sonra düzenlenecek
            /*var bolumOgrenciSayilari = _context.Ogrenciler
                .GroupBy(o => o.BolumId) // Bölümlere göre grupla
                .Select(g => new { BolumId = g.Key, OgrenciSayisi = g.Count() }) // Her bölüm için öğrenci sayısını al
                .ToList(); // Sonucu liste olarak al*/

            return Json(new { maleData, femaleData });
		}
	}
}
