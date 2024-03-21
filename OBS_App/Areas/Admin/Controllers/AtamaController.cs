using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AtamaController : Controller
    {
        private readonly IdentityDataContext _context;

        public AtamaController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OgretmenAta(int id)
        {
            var ders = await _context.Dersler.Include(x => x.Ogretmens).ToListAsync();

            return View(ders);
        }

        public async Task<IActionResult> DersAtaGuncelle(int id)
        {
            if (id == 0)
            {

                ViewBag.Ders = new SelectList(_context.Dersler.Where(d => d.OgretmensId == null).ToList(), "Id", "DersAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View();
            }
            else
            {
                ViewBag.Ders = new SelectList(_context.Dersler.Where(x => x.Id == id), "Id", "DersAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DersAtaGuncelle(Ders model, int id)
        {

            var ders = _context.Dersler.FirstOrDefault(a => a.Id == id);
            if (ders != null)
            {
                ders.OgretmensId = model.OgretmensId;
                _context.Dersler.Update(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction("OgretmenAta");
            }
            else
            {
                ViewBag.Ders = new SelectList(_context.Dersler.ToList(), "Id", "DersAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View(model);
            }



        }
        public IActionResult BaskanAtaGuncelle()
        {
            return View();
        }
        public IActionResult DanismanAtaGuncelle()
        {
            return View();
        }

    }
}
