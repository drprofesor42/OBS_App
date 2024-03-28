using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Hubs;
using OBS_App.Models;
using System.Security.Claims;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    [Authorize(Roles = "Ogretmen")]
    public class DuyuruController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<SignalRHub> _hubContext;

        public DuyuruController(UserManager<AppUser> userManager, IdentityDataContext context, IHubContext<SignalRHub> hubContext) : base(userManager, context)
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

            var duyurular = _context.Duyurular.Include(x => x.Ogretmens).ToList();

            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                ViewBag.kullanıcıId = ogretmen.Id;
            }

            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                if (id == 0)
                {
                    var model = new Duyuru
                    {
                        OgretmensId = ogretmen.Id,
                    };
                    return View(model);

                }
                else
                {
                    var duyuru = await _context.Duyurular.FirstOrDefaultAsync(x => x.Id == id);

                    if (duyuru == null)
                    {
                        // Hata Gönder
                        return RedirectToAction("Index");
                    }
                    else if (duyuru.OgretmensId != ogretmen.Id)
                    {
                        // Kendine ait olamayan mesajı değiştirmeye çalışıyor. Hata
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(duyuru);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(string type, Duyuru model)
        {
            if (ModelState.IsValid)
            {
                if (type == "0")
                {
                    var kullanıcı = await _userManager.GetUserAsync(User);
                    var eposta = await _userManager.Users.Where(x=> x.Email !=kullanıcı.Email).ToListAsync();

                    foreach (var item in eposta)
                    {
                        await _context.Bildirimler.AddAsync(new Bildirim
                        {
                            BildirimBaslik = model.DuyuruBaslik,
                            BildirimDuyuru = model.DuyuruMesaj,
                            BildirimEposta = item.Email,
                        });
                    }
                    await _hubContext.Clients.All.SendAsync("OgretmenDuyuru", model.DuyuruBaslik, model.DuyuruMesaj);
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
            return View(model);
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
