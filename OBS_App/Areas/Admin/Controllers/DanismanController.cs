using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanismanController : Controller
    {

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ata_Guncelle()
        {
            return View();
        }

        public IActionResult Sil()
        {
            return View();
        }

    }
}
