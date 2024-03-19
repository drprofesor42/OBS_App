﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class NotController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public NotController(UserManager<AppUser> userManager, IdentityDataContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                var notlar = _context.Notlar
                    .Include(x => x.Ogrencis)
                    .ThenInclude(x => x.Bolum)
                    .Include(x => x.Ogretmens)
                    .Include(x => x.Ders)
                    .Where(x => x.OgretmensId == ogretmen.Id);

                return View(notlar);
            }
            return View();
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                ViewBag.Dersler = new SelectList(_context.Dersler.Where(x => x.OgretmensId == ogretmen.Id).ToList(), "Id", "DersAd");
                ViewBag.Ogrenciler = new SelectList(_context.Ogrenciler.Include(x => x.Ogretmensler).ToList(), "Id", "OgrenciAd");
                ViewBag.OgretmensId = ogretmen.Id;

                if (id == 0)
                {
                    return View();
                }
                else
                {
                    var notlar = _context.Notlar.Include(x => x.Ogrencis).Include(x => x.Ogretmens).Include(x => x.Bolum).FirstOrDefault(x => x.Id == id);
                    return View(notlar);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Not model, int type)
        {
            var existingNot = await _context.Notlar.FirstOrDefaultAsync(n => n.OgrencisId == model.OgrencisId && n.DersId == model.DersId && n.NotTip == model.NotTip);
            if (existingNot != null)
            {
                type = 1;
            }

            if (ModelState.IsValid)
            {
                if (type == 0)
                {
                    await _context.Notlar.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");

                }
                else if (existingNot != null)
                {
                    existingNot.NotPuan= model.NotPuan;
                    existingNot.NotTarihi = model.NotTarihi;

                    _context.Update(existingNot);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
                else if (type == 1)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Sil(int id)
        {
            var not = _context.Notlar.FirstOrDefault(x => x.Id == id);
            if (not == null)
            {
                // TempData Hata Gönder
            }
            else
            {
                _context.Remove(not);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}