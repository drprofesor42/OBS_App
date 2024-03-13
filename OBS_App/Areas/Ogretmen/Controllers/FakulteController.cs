using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class FakulteController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public FakulteController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> DanısmanOgrenciler()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                var danisanlar = _context.Ogrenciler.Where(d => d.OgretmenId == ogretmen.Id).ToList();
                
                return View(danisanlar);
            }
            return View();
        }

        public IActionResult AkademikTakvim()
        {
            return View();
        }


	}
}
