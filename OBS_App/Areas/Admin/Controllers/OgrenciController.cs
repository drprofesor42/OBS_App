using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;


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
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model, string type)
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

                if (model == null || type == null)
                {
                    ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                    ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAd", "OgretmenAd");
                    // TempData Hata Gönder
                    return View(model);
                }
                else if (type == "0")
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
                    model.Dersler = bolum.Dersler;
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";

                    return RedirectToAction("Index");
                }
                else if (type == "1")
                {
                    var users = await _userManager.FindByEmailAsync(model.OgrenciEposta);
                    
                    if (users != null)
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(users);
                        await _userManager.ResetPasswordAsync(users,token,model.OgrenciParola);
                    }

                        _context.Update(model);
                        _context.SaveChanges();
                        TempData["success"] = "Kayıt güncellendi.";

                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAd", "OgretmenAd");
                return View(model);
            }
        
        // id ye göre db'den kayıt siliyor
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
