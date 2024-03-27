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


        public async Task<IActionResult> Index()
        {
            var dersler = await _context.Dersler.Include(x => x.Ogretmens).Include(x => x.Bolum).ThenInclude(x => x.Ogrencisler).ToListAsync();
            ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
            return View(dersler);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View();
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                var ders = await _context.Dersler.FirstOrDefaultAsync(x => x.Id == id);
                if (ders == null)
                {
                    // Hata Gönder
                    return NotFound();
                }
                return View(ders);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ders model, int id)
        {
            if (ModelState.IsValid)
            {
                var bolum = await _context.Bolumler
                                       .Include(x => x.Fakulte)
                                       .Include(x => x.Ogrencisler)
                                       .FirstOrDefaultAsync(x => x.Id == model.BolumId);
                model.FakulteId = bolum.FakulteId;
                model.Fakulte = bolum.Fakulte;

                if (id == 0)
                {

                    model.Ogrencisler = bolum.Ogrencisler;
                    model.OlusturmaTarihi = DateOnly.FromDateTime(DateTime.Today);

                    await _context.AddAsync(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt eklendi.";

                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View(model);
            }
        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ders = _context.Dersler.FirstOrDefault(x => x.Id == id);
            if (ders == null)
            {
                // TempData Hata Gönder
                return RedirectToAction("Index");
            }
            else
            {
                _context.Remove(ders);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detay(int id)
        {
            var ders = await _context.Dersler
                    .Include(f => f.Ogrencisler)
                    .ToListAsync();
            var model = ders.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
    }

}
