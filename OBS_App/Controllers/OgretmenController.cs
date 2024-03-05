using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Controllers
{
    public class OgretmenController : Controller
    {
        [Authorize(Roles ="Ogretmen")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
