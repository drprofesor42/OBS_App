using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

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
        public async Task<IActionResult> Ekle_Guncelle(AkademikTakvim model, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _context.AkademikTakvimler.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");

                }
                //Güncelleme işlemi
                else
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
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
            }
            return View();
        }

    }
}
