using Microsoft.AspNetCore.Mvc;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DersController : Controller
    {
        private readonly IdentityDataContext _identityDataContext;

        public DersController(IdentityDataContext identityDataContext)
        {
            _identityDataContext = identityDataContext;
        }


        // Dersleri Listeleme Sayfası
        public IActionResult Index()
        {
            var dersler = _identityDataContext.Dersler.ToList();
            return View(dersler);
        }

        // Id 0 gelirse ders ekleme sayfasına, 1 gelirse güncelleme sayfasına yönlendirir (aynı sayfalar ama model gönderiyor)
		public IActionResult Ekle_Guncelle(int? id)
        {
            if (id == 0)
            {
				return View();
			}
            else
            {
				
				var ders = _identityDataContext.Dersler.FirstOrDefault(x => x.dersId == id);
				if (ders == null)
				{
					return NotFound();
				}
				return View(ders);
			}
        }

        // type 0 ise aldığı modeli db'e ekliyor, 1 ise modele göre db kayıt güncelliyor
		[HttpPost]
        public IActionResult Ekle_Guncelle(Ders model, string type)
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
                
                return RedirectToAction("Index");
			}

        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ders = _identityDataContext.Dersler.FirstOrDefault(x => x.dersId == id);
            if (ders == null)
            {
                // TempData Hata Gönder
				return RedirectToAction("Index");
			}
            else
            {
                _identityDataContext.Remove(ders);
                _identityDataContext.SaveChanges();
            }

			return RedirectToAction("Index");
        }
    }
}
