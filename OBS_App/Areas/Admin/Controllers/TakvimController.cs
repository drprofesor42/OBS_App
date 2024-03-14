using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TakvimController : Controller
    {
        private readonly IdentityDataContext _context;
        public TakvimController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var takvimler = await _context.AkademikTakvimler.ToListAsync();

            return View(takvimler);

        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var takvim = await _context.AkademikTakvimler.FirstOrDefaultAsync(x => x.Id == id);
                return View(takvim);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(AkademikTakvim model, int? Kaydet)
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
                        await _context.AkademikTakvimler.AddAsync(model);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Kayıt eklendi.";

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
                        TempData["success"] = "Kayıt güncellendi.";

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
                var user = await _context.AkademikTakvimler.FirstOrDefaultAsync(u => u.Id == id);
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
