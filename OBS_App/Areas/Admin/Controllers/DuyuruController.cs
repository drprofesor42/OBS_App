﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using OBS_App.Data;
using OBS_App.Models;
namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DuyuruController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DuyuruController(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var duyurular = await _context.Duyurular.ToListAsync();
            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {

			if (id == 0)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var model = new Duyuru
                {
                    DuyuruGonderen = user.DuyuruName,
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
                else
                {
                    return View(duyuru);
                }
            }
        }

        [HttpPost]
		public async Task<IActionResult> Ekle_Guncelle(string type, Duyuru model)
		{
            if (ModelState.IsValid)
            {
               
                if (type == "0")
				{
                  

                    //burada hangi öğretmenin gönderdiğini görebiliriz
                  // var user = await _userManager.FindByNameAsync("ogretmen");
                    //var ogretmenıd = await _context.Ogretmenler.FirstOrDefaultAsync(x => x.OgretmenEposta == "aysedemir@gmail.com");
                  //  model.OgretmensId = ogretmenıd.Id;
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
            

			return View (model);
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
