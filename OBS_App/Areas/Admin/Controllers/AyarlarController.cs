using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AyarlarController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;

        public AyarlarController(UserManager<AppUser> UserManager)
        {
            _UserManager = UserManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SifreDegıstır()
        {


            return View();
        }
    }
}
