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
        private readonly UserManager<AppUser> _userManager;
        public DuyuruController(IdentityDataContext identityDataContext, UserManager<AppUser> userManager)
        {
            _identityDataContext = identityDataContext;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var duyurular = _identityDataContext.Duyurular.ToList();
            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            var user = await _userManager.GetUserId();
			var user_id = user.Id;
			ViewBag.UserId = user_id;

			if (id == 0)
            {
                return View(user_id);
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

		public IActionResult Sil()
        {
            return View();
        }

    }
}
