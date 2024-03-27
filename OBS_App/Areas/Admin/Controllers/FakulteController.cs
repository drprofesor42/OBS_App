using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FakulteController : Controller
    {
        private readonly IdentityDataContext _context;
        public FakulteController(IdentityDataContext context)
        {
            _context = context;
        }


        // Fakülteler Listeleme Sayfası
        public async Task<IActionResult> Index()
        {
            var fakulteler = await _context.Fakulteler
                                      .Include(f => f.Bolumler)
                                      .ThenInclude(x => x.Ogretmensler)
                                      .ThenInclude(x => x.Ogrencisler)
                                      .ThenInclude(x => x.Dersler)
                                      .ToListAsync();

            foreach (var fakulte in fakulteler)
            {
                Int32 toplamOgretmenSayisi = 0;
                Int32 toplamOgrenciSayisi = 0;
                Int32 toplamDersSayisi = 0;

                foreach (var bolum in fakulte.Bolumler)
                {
                    toplamOgretmenSayisi += bolum.Ogretmensler.Count();
                    toplamOgrenciSayisi += bolum.Ogrencisler.Count();
                    toplamDersSayisi += bolum.Dersler.Count();
                }

                fakulte.FakulteOgretmenSayisi = toplamOgretmenSayisi;
                fakulte.FakulteOgrenciSayisi = toplamOgrenciSayisi;
                fakulte.FakulteDersSayisi = toplamDersSayisi;

                await _context.SaveChangesAsync();
            }

            return View(fakulteler);

        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var fakulte = await _context.Fakulteler.FirstOrDefaultAsync(x => x.Id == id);
                if (fakulte == null)
                {
                    // Hata Gönder
                    return NotFound();
                }
                return View(fakulte);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Fakulte model, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

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
                return View(model);
            }
        }

        public IActionResult Sil(int id)
        {
            var fakulte = _context.Fakulteler.FirstOrDefault(x => x.Id == id);

            if (id != 0 || fakulte != null)
            {
                _context.Remove(fakulte);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detay(int id)
        {
            var fakulte = await _context.Fakulteler
                    .Include(f => f.Ogretmensler)
                    .Include(f => f.Ogrencisler)
                    .Include(f => f.Bolumler)
                    .ToListAsync();
            var model = fakulte.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
    }
}