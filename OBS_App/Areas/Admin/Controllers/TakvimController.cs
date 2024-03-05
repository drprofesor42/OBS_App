using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TakvimController : Controller
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

    }
}
