using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;


namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public OgrenciController(IdentityDataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.Include(x => x.Bolum).ToListAsync();
            return View(ogrenciler);
        }

        public async Task<IActionResult> Ekle_Guncelle(int? id)
        {
            if (id == 0)
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAd", "OgretmenAd");
                return View();
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAd", "OgretmenAd");
                var ogrenci = _context.Ogrenciler.Include(o => o.Adres).FirstOrDefault(x => x.Id == id);
                if (ogrenci == null)
                {
                    return NotFound();
                }
                return View(ogrenci);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model, int id)
        {
            var bolum = await _context.Bolumler
                .Include(x => x.Dersler)
                .ThenInclude(x => x.Ogretmens)
                .Include(x => x.Fakulte)
                .FirstOrDefaultAsync(x => x.Id == model.BolumId);
            if (bolum != null)
            {
                model.Fakulte = bolum.Fakulte;
                model.FakulteId = bolum.FakulteId;
                model.Ogretmensler = bolum.Ogretmensler;
            }

            if (ModelState.IsValid)
            {
                var dogrula = await _userManager.FindByEmailAsync(model.OgrenciEposta);

                if (id == 0)
                {
                    if (dogrula == null)
                    {
                        var user = new AppUser()
                        {
                            UserName = model.OgrenciEposta,
                            Email = model.OgrenciEposta
                        };
                        await _userManager.CreateAsync(user, model.OgrenciParola);
                        var ogrenci = await _userManager.FindByNameAsync(model.OgrenciEposta);

                        if (ogrenci != null)
                        {
                            await _userManager.AddToRoleAsync(ogrenci, "Ogrenci");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("OgrenciEposta", "Bu E-posta daha önce alınmış");
                        ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                        return View(model);
                    }
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                else if (id == 1)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAd", "OgretmenAd");
                return View(model);
            }
        }
        public IActionResult Sil(int id)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(x => x.Id == id);
            if (ogrenci == null)
            {
                // TempData Hata Gönder
                return RedirectToAction("Index");
            }
            else
            {
                _context.Remove(ogrenci);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
