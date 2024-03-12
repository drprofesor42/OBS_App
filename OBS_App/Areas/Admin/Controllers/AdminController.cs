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

			int[] maleData = {_context.Ogrenciler.Where(x => x.ogrenciCinsiyet == "Erkek").Count()}; // Bu metodu örnek olarak ekleyin
			int[] femaleData = {_context.Ogrenciler.Where(x => x.ogrenciCinsiyet == "Kadın").Count()}; // Bu metodu örnek olarak ekleyin

            // S-Bar

			return Json(new { maleData, femaleData });
		}

    }
}
