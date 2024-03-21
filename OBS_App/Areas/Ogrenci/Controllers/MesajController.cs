using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class MesajController : BaseController
    {
        public MesajController(IdentityDataContext context, UserManager<AppUser> userManager) : base(userManager, context)
        {
        }

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
