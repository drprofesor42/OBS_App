﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model, int id, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var dogrula = await _userManager.FindByEmailAsync(model.OgrenciEposta);
                    if (dogrula != null)
                    {
                        ModelState.AddModelError("OgrenciEposta", "Bu E-posta daha önce alınmış");
                        ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");

                    }
                    var bosluk = "";
                    if (file != null)
                    {
                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        bosluk = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(bosluk))
                        {
                            ModelState.AddModelError("", "Geçerli bir resim seçiniz.");
                            return View(model);
                        }
                    }
                }
                if (id == 0)
                {

                    if (file != null)
                    {
                        
                        var uzantısı = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", uzantısı);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        model.OgrenciFotograf = uzantısı;
                    }

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

                    var bolum = await _context.Bolumler
                                   .Include(x => x.Dersler)
                                   .Include(x => x.Ogretmensler)
                                   .Include(x => x.Fakulte)
                                   .FirstOrDefaultAsync(x => x.Id == model.BolumId);
                    if (bolum != null)
                    {
                        model.Fakulte = bolum.Fakulte;
                        model.Dersler = bolum.Dersler;
                        model.FakulteId = bolum.FakulteId;
                        model.Ogretmensler = bolum.Ogretmensler;
                    }
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                else if (id == 1)
                {
                    
                    if (file != null)
                    {
                        
                        var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                        var resimuzantı = Path.GetExtension(file.FileName);
                        if (!uzanti.Contains(resimuzantı))
                        {
                            ModelState.AddModelError("", "Geçerli bir resim seçiniz.");
                            return View(model);
                        }
                        var uzantısı = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", uzantısı);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);

                        }
                        model.OgrenciFotograf = uzantısı;
                    }

                    var users = await _userManager.FindByEmailAsync(model.OgrenciEposta);

                    if (users != null)
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(users);
                        await _userManager.ResetPasswordAsync(users, token, model.OgrenciParola);
                    }
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
