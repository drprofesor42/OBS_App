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
                    await _hubContext.Clients.All.SendAsync("ReceiveDuyuru", model.DuyuruBaslik, model.DuyuruMesaj);
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

    }
}
