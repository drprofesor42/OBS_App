using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class MesajController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MesajGönder()
        {
            return View();
        }
    }
}
