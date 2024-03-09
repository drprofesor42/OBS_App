using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FakulteController : Controller
    {
        private readonly IdentityDataContext _identityDataContext;
        public FakulteController(IdentityDataContext identityDataContext)
        {
            _identityDataContext = identityDataContext;
        }


        // Fakülteler Listeleme Sayfası
        public IActionResult Index()
        {
            var fakulteler = _identityDataContext.Fakulteler.ToList();
            return View(fakulteler);
        }

        public IActionResult Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                return View();
			}
            else
            {
                var fakulte = _identityDataContext.Fakulteler.FirstOrDefault(x => x.Id == id);
                if (fakulte == null)
                {
                    // Hata Gönder
                    return NotFound();
				}
                return View(fakulte);
            }
        }

        [HttpPost]
        public IActionResult Ekle_Guncelle(string type, Fakulte model)
        {
            if(ModelState.IsValid)
            {
                if (model == null || type == null)
                {
                    return View(model);
                    // TempData Hata Gönder
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
                    return View(model);
                    // Hata Gönder
                }
            }
			
            return View(model);
        }

		public IActionResult Sil(int id)
        {
			var fakulte = _identityDataContext.Fakulteler.FirstOrDefault(x => x.Id == id);

			if (id == 0 || fakulte == null)
            {
                // Hata Gönder
            }
            else
            {
                _identityDataContext.Remove(fakulte);
                _identityDataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
