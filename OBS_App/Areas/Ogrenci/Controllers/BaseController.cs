using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OBS_App.Models;
using OBS_App.ViewsModel;

namespace OBS_App.Areas.Ogrenci.Controllers
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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var kullanıcı = _userManager.GetUserAsync(User).Result;
            if (kullanıcı != null)
            {
                var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);

                if (ogrenci != null)
                {
                    ViewBag.Fotograf = ogrenci.OgrenciFotograf;
                    ViewBag.AdSoyad = ogrenci.OgrenciAdSoyad;
                }


                LayoutViewModel layoutViewModel = new LayoutViewModel
                {
                    ImagePath = ogrenci.OgrenciFotograf
                };

                ViewBag.LayoutViewModel = layoutViewModel;
                base.OnActionExecuted(context);
            }
        }
    }
}
