using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DersController : Controller
    {
        private readonly IdentityDataContext _context;

        public DersController(IdentityDataContext context)
        {
            _context = context;
        }


        // Dersleri Listeleme Sayfası
        public async Task<IActionResult> Index()
        {
            var dersler = await _context.Dersler.Include(x => x.Ogretmens).Include(x=> x.Bolum).ThenInclude(x=> x.Ogrencisler).ToListAsync();
            return View(dersler);
        }

        // Id 0 gelirse ders ekleme sayfasına, 1 gelirse güncelleme sayfasına yönlendirir (aynı sayfalar ama model gönderiyor)
		public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                return View();
			}
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                var ders = await _context.Dersler.FirstOrDefaultAsync(x => x.Id == id);
				if (ders == null)
				{
                    // Hata Gönder
					return NotFound();
				}
				return View(ders);
			}
        }

        // type 0 ise aldığı modeli db'e ekliyor, 1 ise modele göre db kayıt güncelliyor
		[HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ders model, string type)
        {

            if (ModelState.IsValid)
            {
                if (model == null || type == null)
                {
                    ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                    return View(model);
                    // TempData Hata Gönder
                }
                else if (type == "0")
                {
                     await _context.AddAsync(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (type == "1")
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
            ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
            return View(model);
        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ders = _context.Dersler.FirstOrDefault(x => x.Id == id);
            if (ders == null)
            {
                // TempData Hata Gönder
			}
            else
            {
                _context.Remove(ders);
                _context.SaveChanges();
            }

			return RedirectToAction("Index");
        }
    }
}
