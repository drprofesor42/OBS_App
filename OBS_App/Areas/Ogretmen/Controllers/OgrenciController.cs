using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class OgrenciController : Controller
    {
        public IActionResult Ogrencilerim()
        {
            return View();
        }
    }
}
