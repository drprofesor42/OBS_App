using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IdentityDataContext _context;

        public AdminController(IdentityDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ogrenci_sayısı = _context.Ogrenciler.Count();
            ViewBag.ogretmen_sayısı = _context.Ogretmenler.Count();
            ViewBag.bolum_sayısı = _context.Bolumler.Count();
            ViewBag.fakulte_sayısı = _context.Fakulteler.Count();


			return View();
        }

        [HttpPost]
        public IActionResult Data()
        {

			int[] femaleData = {_context.Ogrenciler.Where(x => x.OgrenciCinsiyet == 0).Count()};
			int[] maleData = {_context.Ogrenciler.Where(x => x.OgrenciCinsiyet == 1).Count()};

            // S-Bar

			return Json(new { maleData, femaleData });
		}

    }
}
