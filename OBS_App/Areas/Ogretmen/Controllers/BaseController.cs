using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.ViewsModel;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public BaseController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var kullanıcı = _userManager.GetUserAsync(User).Result;
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(d => d.OgretmenEposta == kullanıcı.Email);

                if (ogretmen != null)
                {
                    ViewBag.fotograf = ogretmen.OgretmenFotograf;
                    ViewBag.adsoyad = ogretmen.OgretmenAdSoyad;
                }


                LayoutViewModel layoutViewModel = new LayoutViewModel
                {
                    ImagePath = ogretmen.OgretmenFotograf
                };
                
                ViewBag.LayoutViewModel = layoutViewModel;
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
