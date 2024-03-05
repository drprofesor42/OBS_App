using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FakulteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle_Guncelle()
        {
            return View();
        }

        public IActionResult Sil()
        {
            return View();
        }

        public IActionResult ProfAta_Sil()
        {
            return View();
        }

    }
}
