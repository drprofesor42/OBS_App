using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AtamaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DersAtaGuncelle()
        {
            return View();
        }

        public IActionResult BaskanAtaGuncelle()
        {
            return View();
        }
        public IActionResult DanismanAtaGuncelle()
        {
            return View();
        }

    }
}
