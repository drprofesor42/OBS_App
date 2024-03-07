using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;


namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _identityDataContext;
        public OgrenciController(IdentityDataContext identityDataContext)
        {
            _identityDataContext = identityDataContext;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _identityDataContext.Ogrenciler.ToListAsync();
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
                Console.WriteLine("Ogrenci Güncelle");
                Console.WriteLine(id);
                var ogrenci = _identityDataContext.Ogrenciler.FirstOrDefault(x => x.Id == id);
                if (ogrenci == null)
                {
                    return NotFound();
                }
                return View(ogrenci);
            }
        }
        [HttpPost]
        public IActionResult Ekle_Guncelle(Ogrencis model, string type)
        {

            if (ModelState.IsValid)
            {
                if (model == null || type == null)
                {
                    // TempData Hata Gönder
                    return RedirectToAction("Index");
                }
                else if (type == "0")
                {
                    _identityDataContext.Add(model);
                    _identityDataContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else if (type == "1")
                {
                    _identityDataContext.Update(model);
                    _identityDataContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine("How it possible?");
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ogrenci = _identityDataContext.Ogrenciler.FirstOrDefault(x => x.Id == id);
            if (ogrenci == null)
            {
                // TempData Hata Gönder
                return RedirectToAction("Index");
            }
            else
            {
                _identityDataContext.Remove(ogrenci);
                _identityDataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
