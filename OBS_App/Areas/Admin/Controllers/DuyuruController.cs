using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DuyuruController : Controller
    {
        private readonly IdentityDataContext _identityDataContext;
        public DuyuruController(IdentityDataContext identityDataContext, UserManager<AppUser> userManager)
        {
            _identityDataContext = identityDataContext;
        }


        public IActionResult Index()
        {
            var duyurular = _identityDataContext.Duyurular.ToList();
            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
			if (id == 0)
            {
                return View();
            }
            else
            {
                var duyuru = _identityDataContext.Duyurular.FirstOrDefault(x => x.duyuruId == id);
                if (duyuru == null)
                {
                    // Hata Gönder
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(duyuru);
                }
            }
        }

        [HttpPost]
		public IActionResult Ekle_Guncelle(string type, Duyuru model)
		{
            if (type == "0")
            {
                _identityDataContext.Duyurular.Add(model);
                _identityDataContext.SaveChanges();
            }
            else
            {
				_identityDataContext.Duyurular.Update(model);
				_identityDataContext.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		public IActionResult Sil(int id)
        {
            var duyuru = _identityDataContext.Duyurular.FirstOrDefault(x => x.duyuruId == id);
            if (duyuru == null)
            {
                // Hata gönder
            }
            else
            {
                _identityDataContext.Remove(duyuru);
                _identityDataContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
