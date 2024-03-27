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
    public class BolumController : Controller
    {
        private readonly IdentityDataContext _context;

        public BolumController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
			var bolum = await _context.Bolumler.Include(x => x.Dersler).Include(x => x.Ogrencisler).Include(x => x.Ogretmensler).ToListAsync();
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
            return View(bolum);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                ViewBag.Fakulteler = new SelectList(await _context.Fakulteler.ToListAsync(), "Id", "FakulteAd");
                ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View();

            }
            else
            {
                ViewBag.Fakulteler = new SelectList(await _context.Fakulteler.ToListAsync(), "Id", "FakulteAd");
                ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                var bolum = await _context.Bolumler.FirstOrDefaultAsync(x => x.Id == id);
                return View(bolum);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Bolum model, int id)
        {
            if (ModelState.IsValid)
            {
                var fakulte = await _context.Fakulteler.FirstOrDefaultAsync(x => x.Id == model.FakulteId);
                if (fakulte != null)
                {
                    model.FakulteId = fakulte.Id;
                    model.Fakulte = fakulte;
                }

                if (model.BolumBaskani == null)
                {
                    model.BolumBaskani = "Seçilmedi";
                }

                if (id == 0)
                {

                    await _context.Bolumler.AddAsync(model);
                    await _context.SaveChangesAsync();
					TempData["success"] = "Kayıt eklendi.";
					return RedirectToAction("Index");
                }
                else
                {
                    _context.Bolumler.Update(model);
                    await _context.SaveChangesAsync();
					TempData["success"] = "Kayıt güncellendi.";
					return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.Fakulteler = new SelectList(await _context.Fakulteler.ToListAsync(), "Id", "FakulteAd");
                ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View(model);
            }
        }
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                //Hata mesajı bolum bulunamadı
                return RedirectToAction("Index");
            }
            else
            {
                var bolum = await _context.Bolumler.FirstOrDefaultAsync(x => x.Id == id);

                if (bolum != null)
                {
                    _context.Bolumler.Remove(bolum);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
        public async Task<IActionResult> Detay(int id)
        {
            var bolum = await _context.Bolumler
                    .Include(f => f.Dersler)
                    .Include(f => f.Ogretmensler)
                    .Include(f => f.Ogrencisler)
                    .ToListAsync();
            var model = bolum.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
    }
}
