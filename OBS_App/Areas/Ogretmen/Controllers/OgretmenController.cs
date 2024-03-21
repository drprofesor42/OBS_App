using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Areas.Admin.ViewsModel;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    [Authorize(Roles = "Ogretmen")]
    public class OgretmenController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OgretmenController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Duyurular()
        {
            var duyurular = _context.Duyurular.ToList();
            return View(duyurular);
        }

        public IActionResult SifreDegistir()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SifreDegistir(SifreDegistirViewsModel model)
		{
			if (ModelState.IsValid)
			{
				var users = await _userManager.GetUserAsync(User);
				var token = await _userManager.GeneratePasswordResetTokenAsync(users);
				if (users != null)
				{
					await _userManager.ResetPasswordAsync(users, token, model.Parola);
                    TempData["success"] = "Şifre başarıyla değiştirildi!";

					return RedirectToAction("Index");
				}
			}
			return View(model);
		}

		public async Task<IActionResult> Profilim()
        {

            var users = await _userManager.GetUserAsync(User);

            var ogretmen = _context.Ogretmenler
                .Include(x => x.Fakulte)
                .Include(x => x.Bolum)
                .Include(x=> x.Adres)
                .Where(x => x.OgretmenEposta == users.Email);
            return View(ogretmen);
        }
    }
}
