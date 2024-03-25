using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class NotController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityDataContext _context;

        public NotController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
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
                ViewBag.Ogrenciler = new SelectList(_context.Ogrenciler.Where(x => x.BolumId == ogretmen.BolumId).Include(x => x.Ogretmensler).ToList(), "Id", "OgrenciAd");
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
            var existingNot = await _context.Notlar.FirstOrDefaultAsync(n => n.OgrencisId == model.OgrencisId && n.DersId == model.DersId);

            if (ModelState.IsValid)
            {
                if (type == 0 && existingNot == null)
                {
                    await _context.Notlar.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi!";
                    return RedirectToAction("Index");

                }
                else if (existingNot != null)
                {
                    existingNot.NotOdev= model.NotOdev;
                    existingNot.NotVize= model.NotVize;
                    existingNot.NotFinal = model.NotFinal;

                    existingNot.NotOdevTarih = model.NotOdevTarih;
                    existingNot.NotVizeTarih = model.NotVizeTarih;
                    existingNot.NotFinalTarih = model.NotFinalTarih;

                    existingNot.NotOdevSaat = model.NotOdevSaat;
                    existingNot.NotVizeSaat = model.NotVizeSaat;
                    existingNot.NotFinalSaat = model.NotFinalSaat;

                    _context.Update(existingNot);
                    _context.SaveChanges();
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
