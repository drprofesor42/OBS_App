using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class OgrenciIslemController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public OgrenciIslemController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Ogrencilerim()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                // 
            }

            return View();
        }

        public IActionResult Notlar()
        {
            return View();
        }

        public IActionResult Yoklama()
        {
            return View();
        }
    
    }
}
