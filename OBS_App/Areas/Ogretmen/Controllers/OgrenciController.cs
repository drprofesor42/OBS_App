using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class OgrenciController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public OgrenciController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OgrenciListem()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                //var ogrenciler = _context

                return View();
            }
            return View();
        }
    }
}
