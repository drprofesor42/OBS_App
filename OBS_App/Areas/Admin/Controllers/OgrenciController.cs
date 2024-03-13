using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;
using Microsoft.AspNetCore.Authorization;


namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _context;
        public OgrenciController(IdentityDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public IActionResult Ekle_Guncelle(int? id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {

                var ogrenci = _context.Ogrenciler.FirstOrDefault(x => x.Id == id);
                if (ogrenci == null)
                {
                    return NotFound();
                }
                return View(ogrenci);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model, string type)
        {

            if (ModelState.IsValid)
            {
                if (model == null || type == null)
                {
                    // TempData Hata Gönder
                    return View(model);
                }
                else if (type == "0")
                {
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";

                    return RedirectToAction("Index");
                }
                else if (type == "1")
                {

                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(x => x.Id == id);
            if (ogrenci == null)
            {
                // TempData Hata Gönder
                return RedirectToAction("Index");
            }
            else
            {
                _context.Remove(ogrenci);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
