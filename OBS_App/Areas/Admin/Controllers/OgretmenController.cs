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
    public class OgretmenController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _rolemanger;
        public OgretmenController(IdentityDataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> rolemanger)
        {
            _context = context;
            _userManager = userManager;
            _rolemanger = rolemanger;
        }
        public async Task<IActionResult> Index()
        {
            var ogretmenler = await _context.Ogretmenler.Include(x => x.Adres).ToListAsync();
            return View(ogretmenler);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                return View();
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                var ogrt = await _context.Ogretmenler.Include(x => x.Adres).FirstOrDefaultAsync(x => x.Id == id);
                return View(ogrt);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogretmens model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var bolum = await _context.Bolumler
                                   .Include(x => x.Dersler)
                                   .Include(x => x.Ogretmensler)
                                   .Include(x => x.Fakulte)
                                   .FirstOrDefaultAsync(x => x.Id == model.BolumId);
                model.Fakulte = bolum.Fakulte;
                model.FakulteId = bolum.FakulteId;
                model.Ogrencisler = bolum.Ogrencisler;

                if (id == 0)
                {
                    var dogrula = await _userManager.FindByEmailAsync(model.OgretmenEposta);
                    if (dogrula != null)
                    {
                        ModelState.AddModelError("OgretmenEposta", "Bu E-posta daha önce alınmış");
                        ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                        return View(model);
                    }
                    else if (file != null)
                    {
                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        var resimuzanti = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(resimuzanti))
                        {
                            ModelState.AddModelError("OgretmenFotograf", "Geçerli bir resim seçiniz. jpg,jpeg,png");
                            ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("OgretmenFotograf", "Resmim alanı boş olamaz");
                        ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                        return View(model);
                    }

                    if (file != null)
                    {

                        var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                        var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                        using (var stream = new FileStream(resimyolu, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        model.OgretmenFotograf = random;
                    }
                    var user = new AppUser()
                    {
                        UserName = model.OgretmenEposta,
                        Email = model.OgretmenEposta
                    };
                    await _userManager.CreateAsync(user, model.OgretmenParola);
                    var ogretmen = await _userManager.FindByNameAsync(model.OgretmenEposta);


                    if (ogretmen != null)
                    {
                        await _userManager.AddToRoleAsync(ogretmen, "Ogretmen");
                    }
 

                    await _context.Ogretmenler.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (file != null)
                    {
                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        var resimuzantı = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(resimuzantı))
                        {
                            ModelState.AddModelError("OgretmenFotograf", "Geçerli bir resim seçiniz. jpg,jpeg,png");
                            ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                            return View(model);
                        }
                        var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);

                        }
                        model.OgretmenFotograf = random;
                    }

                    var users = await _userManager.FindByEmailAsync(model.OgretmenEposta);

                    if (users != null)
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(users);
                        await _userManager.ResetPasswordAsync(users, token, model.OgretmenParola);
                    }
                    else
                    {

                        var user = new AppUser()
                        {
                            UserName = model.OgretmenEposta,
                            Email = model.OgretmenEposta

                        };
                        await _userManager.CreateAsync(user, model.OgretmenParola);
                        var ogretmen = await _userManager.FindByNameAsync(model.OgretmenEposta);
                    }


                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt güncellendi.";

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                return View(model);
            }
        }

        public async Task<IActionResult> Sil(int? id)
        {

            // Identity ve kendi dbmizden silme
            var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.Id == id);
            var ogretmenIdentity = _context.Users.FirstOrDefault(d => d.Email == ogretmen.OgretmenEposta);

            if (ogretmen != null && ogretmenIdentity != null)
            {
                _context.Remove(ogretmenIdentity);
                _context.Remove(ogretmen);
                _context.SaveChanges();
            }

            // Hata
            return RedirectToAction("Index");
        }

    }
}
