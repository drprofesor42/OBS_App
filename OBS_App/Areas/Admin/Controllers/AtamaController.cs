using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class AtamaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DersAta()
        {
            return View();
        }

        public IActionResult DanismanAta()
        {
            return View();
        }
        public IActionResult BaskanAta()
        {
            return View();
        }
    }
}
