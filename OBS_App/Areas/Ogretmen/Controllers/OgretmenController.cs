using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    [Authorize(Roles = "Ogretmen")]
    public class OgretmenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
