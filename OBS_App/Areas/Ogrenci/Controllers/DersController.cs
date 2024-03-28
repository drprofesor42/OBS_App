using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OBS_App.Models;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class DersController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DersController(IdentityDataContext context, UserManager<AppUser> userManager) : base(userManager, context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Derslerim()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                // Kullanıcının derslerini çek
                var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
                var dersler = _context.Ogrenciler
                    .Include(x => x.Dersler)
                    .ThenInclude(x => x.Ogretmens)
                    .Include(x => x.Notlar)
                    .Where(x => x.Id == ogrenci.Id)
                    .ToList();

                return View(dersler);
            }

            // Hata Gönder
            return View();
        }

        public async Task<IActionResult> DersProgrami()
        {

            return View();

        }
        public async Task<IActionResult> DersProgramiTakvim()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            var ogrenci = await _context.Ogrenciler.FirstOrDefaultAsync(x => x.OgrenciEposta == kullanıcı.Email);
            var dersler = await _context.Dersler.Where(x => x.Bolum.Id == ogrenci.BolumId).ToListAsync();
            return Json(dersler);


        }

        public async Task<IActionResult> SınavSonuc()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                // Kullanıcının derslerini çek
                var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
                var dersler = _context.Notlar.Include(x => x.Ogretmens).Include(x => x.Ders).Where(x => x.OgrencisId == ogrenci.Id).ToList();

                ViewBag.sınıfNotOrtalamaları = _context.Notlar
                    .Where(x => x.Ogrencis.BolumId == ogrenci.BolumId)
                    .GroupBy(x => x.Ders)
                    .Select(group => new
                    {
                        DersAdi = group.Key,
                        NotOdevOrtalamasi = group.Average(x => x.NotOdev),
                        NotVizeOrtalamasi = group.Average(x => x.NotVize),
                        NotFinalOrtalamasi = group.Average(x => x.NotFinal),
                        ToplamOrtalama = (group.Average(x => x.NotOdev) * 0.25 + group.Average(x => x.NotVize) * 0.35 + group.Average(x => x.NotFinal) * 0.40)
                    })
                    .ToList();

                return View(dersler);
            }

            // Hata Gönder
            return View();
        }

        public IActionResult SınavTakvim()
        {
            return View();
        }

    }
}
