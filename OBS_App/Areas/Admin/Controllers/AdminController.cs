
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_App.Areas.Admin.ViewsModel;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Sayaçlar
            ViewBag.ogrenci_sayısı = _context.Ogrenciler.Count();
            ViewBag.ogretmen_sayısı = _context.Ogretmenler.Count();
            ViewBag.bolum_sayısı = _context.Bolumler.Count();
            ViewBag.fakulte_sayısı = _context.Fakulteler.Count();

            // Son 4 duyuruyu alıyoruz
            var duyurular = await _context.Duyurular.Include(x => x.Ogretmens).OrderByDescending(x => x.Id).Take(4).ToListAsync();
            if (duyurular.Count() != 0)
            {
                ViewBag.duyurular = duyurular;
            }
            else
            {
                ViewBag.duyurular = null;
            }

            // Son 5 Akademik Takvim verileri
            ViewBag.takvim = _context.AkademikTakvimler.OrderByDescending(x => x.Id).Take(5).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Data()
        {
            // Bar
            int[] maleData = { _context.Ogrenciler.Where(x => x.OgrenciCinsiyet == "Erkek").Count() };
            int[] femaleData = { _context.Ogrenciler.Where(x => x.OgrenciCinsiyet == "Kız").Count() };

            // S-Bar
            // Bölümlere göre öğrenci sayılarını al, sonra düzenlenecek
            var bolumOgrenciSayilari = _context.Ogrenciler
                .Include(o => o.Bolum) // Bölüm bilgisini ekleyerek join işlemi yapar
                .GroupBy(o => new { o.BolumId, o.Bolum.BolumAd }) // Bölümlere göre grupla
                .Select(g => new { BolumAd = g.Key.BolumAd, OgrenciSayisi = g.Count() }) // Her bölüm için bölüm adını ve öğrenci sayısını al
                .ToList(); // Sonucu liste olarak al

            return Json(new { maleData, femaleData, bolumOgrenciSayilari });
        }

        public async Task<IActionResult> SifreDegistir(int id)
        {
            if (id == 1)
            {
                ViewBag.user = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciEposta", "OgrenciEposta");
            }
            else if (id == 2)
            {
                ViewBag.user = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenEposta", "OgretmenEposta");
            }
            else
            {
                TempData["success"] = "Şifre başarıyla değiştirildi.";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifreDegistir(SifreDegistirViewsModel model, int id)
        {
            if (ModelState.IsValid)
            {
                //ogrenci
                if (id == 1)
                {
                    var users = await _userManager.FindByEmailAsync(model.Eposta);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(users);

                    if (users != null)
                    {
                        await _userManager.ResetPasswordAsync(users, token, model.Parola);
                        TempData["success"] = "Şifre başarıyla değiştirildi!";
                    }
                    ViewBag.user = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciEposta", "OgrenciEposta");
                }

                //ogretmen
                else if (id == 2)
                {
                    var users = await _userManager.FindByEmailAsync(model.Eposta);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(users);

                    if (users != null)
                    {
                        await _userManager.ResetPasswordAsync(users, token, model.Parola);
                        TempData["success"] = "Şifre başarıyla değiştirildi!";
                    }
                    ViewBag.user = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenEposta", "OgretmenEposta");
                }

                else//admin
                {
                    var users = await _userManager.GetUserAsync(User);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(users);

                    if (users != null)
                    {
                        var result = await _userManager.ResetPasswordAsync(users, token, model.Parola);
                        if (result.Succeeded)
                        {
                            TempData["success"] = "Şifre başarıyla değiştirildi.";
                        }
                    }
                }

                return RedirectToAction("Index");
            }
        
            if (id == 1)
            {
                ViewBag.user = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciEposta", "OgrenciEposta");
            }
            else if (id == 2)
            {
                ViewBag.user = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenEposta", "OgretmenEposta");
            }
            return View(model);
        }
    }
}
