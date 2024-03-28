using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class DuyuruController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public DuyuruController(IdentityDataContext context, UserManager<AppUser> userManager) : base(userManager, context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Index()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            var bildirim = await _context.Bildirimler.Where(x => x.BildirimEposta == kullanıcı.Email).ToListAsync();

            foreach (var bld in bildirim)
            {
                bld.BildirimOkunma = true;
            }
            _context.Bildirimler.UpdateRange(bildirim);
            _context.SaveChanges();
            var duyurular = _context.Duyurular.Include(x => x.Ogretmens).ToList();
            return View(duyurular);
        }

        public async Task<IActionResult> Bildirim(int id)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var bildirim = await _context.Bildirimler.Where(x => x.BildirimEposta == user.Email).ToListAsync();

            var okundu = await _context.Bildirimler.FirstOrDefaultAsync(x => x.Id == id);
            if (okundu != null)
            {
                okundu.BildirimOkunma = true;
                _context.Bildirimler.Update(okundu);
                await _context.SaveChangesAsync();

            }
            return Json(bildirim);
        }

        [HttpPost]
        public async Task<IActionResult> Bildirim()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var bildirim = await _context.Bildirimler.Where(x => x.BildirimEposta == user.Email).ToListAsync();
            _context.Bildirimler.RemoveRange(bildirim);
            await _context.SaveChangesAsync();
            return Json(bildirim);
        }
    }
}
