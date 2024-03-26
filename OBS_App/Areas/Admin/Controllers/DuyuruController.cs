using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Hubs;
using OBS_App.Models;
namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DuyuruController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<SignalRHub> _hubContext;

        public DuyuruController(IdentityDataContext context, UserManager<AppUser> userManager, IHubContext<SignalRHub> hubContext)
        {
            _userManager = userManager;
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            var bildirim = await _context.Bildirimler.Where(x => x.BildirimEposta == kullanıcı.Email).ToListAsync();

            foreach (var bld in bildirim)
            {
                bld.BildirimOkunma = true;
            }
            _context.Bildirimler.UpdateRange(bildirim);
            _context.SaveChanges();

            var duyurular = await _context.Duyurular.Include(x => x.Ogretmens).ToListAsync();
            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {

                return View();
            }
            else
            {
                var duyuru = await _context.Duyurular.FirstOrDefaultAsync(x => x.Id == id);
                if (duyuru == null)
                {
                    // Hata Gönder
                    return RedirectToAction("Index");
                }
                return View(duyuru);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(int id, Duyuru model)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var kullanıcı = await _userManager.GetUserAsync(User);
                    var eposta = await _userManager.Users.Where(x => x.Email != kullanıcı.Email).ToListAsync();

                    foreach (var item in eposta)
                    {
                        await _context.Bildirimler.AddAsync(new Bildirim
                        {
                            BildirimBaslik = model.DuyuruBaslik,
                            BildirimDuyuru = model.DuyuruMesaj,
                            BildirimEposta = item.Email,
                        });
                    }

                    await _hubContext.Clients.All.SendAsync("AdminDuyuru", model.DuyuruBaslik, model.DuyuruMesaj);
                    await _context.Duyurular.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Duyurular.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Sil(int id)
        {
            var duyuru = _context.Duyurular.FirstOrDefault(x => x.Id == id);
            if (duyuru == null)
            {
                // Hata gönder
            }
            else
            {
                _context.Remove(duyuru);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
