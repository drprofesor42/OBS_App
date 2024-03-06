using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Admin.Controllers
{
    public class AtamaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DersAta_Sil()
        {
            return View();
        }

        public IActionResult BolumAta_Sil()
        {
            return View();
        }
    }
}
