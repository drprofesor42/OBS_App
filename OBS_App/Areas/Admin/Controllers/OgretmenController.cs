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
        public async Task<IActionResult> Ekle_Guncelle(Ogretmens model, int id, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    var dogrula = await _userManager.FindByEmailAsync(model.OgretmenEposta);
                    if (dogrula != null)
                    {
                        ModelState.AddModelError("OgretmenEposta", "Bu E-posta daha önce alınmış");
                        ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                    }
                    else if (file != null)
                    {
                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        var resimuzanti = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(resimuzanti))
                        {
                            ModelState.AddModelError("OgretmenFotograf", "Geçerli bir resim seçiniz. jpg,jpeg,png");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("OgretmenFotograf", "Resmim alanı boş olamaz");
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
                    var bolum = await _context.Dersler
                                  .Include(x => x.Fakulte)
                                  .Include(x => x.Ogrencisler)
                                  .FirstOrDefaultAsync(x => x.Id == model.BolumId);

                    if (bolum != null)
                    {
                        model.Ogrencisler = bolum.Ogrencisler;
                        model.Fakulte = bolum.Fakulte;
                        model.FakulteId = bolum.FakulteId;
                    }
                    await _context.Ogretmenler.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                if (id == 1)
                {
                    if (file != null)
                    {

                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        var resimuzantı = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(resimuzantı))
                        {
                            ModelState.AddModelError("OgretmenFotograf", "Geçerli bir resim seçiniz. jpg,jpeg,png");
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
                else
                {
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
            if (id != null)
            {
                var user = await _context.Ogretmenler.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _context.Remove(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    //Kullanıcı bulunamadı
                }
            }
            else
            {
                //hata mesajı
            }

            return View();
        }

    }
}
