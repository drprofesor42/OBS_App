using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OgretmenController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public OgretmenController(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmenler = await _context.Ogretmenler.ToListAsync();

            return View(ogretmenler);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var ogrt = await _context.Ogretmenler.FirstOrDefaultAsync(x => x.Id == id);
                return View(ogrt);

            }


        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogretmens model, int? Kaydet)
        {
            if (Kaydet == null)
            {
                // hata
                return View();
            }
            else
            {
                //ekleme
                if (Kaydet == 1)
                {
                    if (ModelState.IsValid)
                    {
                        var user = new AppUser
                        {
                            UserName = model.OgretmenEposta,
                            Email = model.OgretmenEposta,
                        };

                        IdentityResult result = await _userManager.CreateAsync(user, model.OgretmenParola);

                        _context.Add(model);
                        _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //hata mesajı
                    }
                }
                //Güncelleme işlemi
                if (Kaydet == 2)
                {
                    if (ModelState.IsValid)
                    {

                        _context.Update(model);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index");

                    }
                }
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
