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
        public async Task<IActionResult> DersAtaGuncelle(Ders model, int id, int modal, int ogretmenAdSoyad)
        {
            if (modal != 0)
            {
                var deneme = _context.Dersler.FirstOrDefault(b => b.Id == modal);
                if (deneme != null)
                {
                    deneme.OgretmensId = ogretmenAdSoyad;
                    _context.Dersler.Update(deneme);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "İşlem Başarılı!";
                    return RedirectToAction("Index", "Ders");
                }

            }

            var ders = _context.Dersler.FirstOrDefault(a => a.Id == id);

            if (ders != null)
            {
                ders.OgretmensId = model.OgretmensId;
                _context.Dersler.Update(ders);
                await _context.SaveChangesAsync();
                TempData["success"] = "İşlem Başarılı!";
                return RedirectToAction("OgretmenAta");
            }
            else
            {
                ViewBag.Ders = new SelectList(_context.Dersler.ToList(), "Id", "DersAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View(model);
            }

        }
        public async Task<IActionResult> BaskanIndex(int id)
        {
            var bolum = await _context.Bolumler.ToListAsync();
            return View(bolum);
        }
        public async Task<IActionResult> BaskanAtaGuncelle(int id)
        {
            if (id == 0)
            {
                ViewBag.Bolumler = new SelectList(_context.Bolumler.Where(b => b.BolumBaskani == "Seçiniz").ToList(), "Id", "BolumAd");
                ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View();

            }
            else
            {
                ViewBag.Bolumler = new SelectList(_context.Bolumler.Where(x => x.Id == id), "Id", "BolumAd");
                ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> BaskanAtaGuncelle(Bolum model, int id, int modal, string bolumBaskani)
        {
            if (modal != 0)
            {
                var deneme = _context.Bolumler.FirstOrDefault(b => b.Id == modal);
                if (deneme != null)
                {
                    deneme.BolumBaskani = bolumBaskani;
                    _context.Bolumler.Update(deneme);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "İşlem Başarılı!";
                    return RedirectToAction("Index", "Bolum");
                }

            }
            var bolum = _context.Bolumler.FirstOrDefault(b => b.Id == id);
            if (bolum != null)
            {
                bolum.BolumBaskani = model.BolumBaskani;

                if (bolum.BolumBaskani != null)
                {
                    _context.Bolumler.Update(bolum);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "İşlem Başarılı!";
                    return RedirectToAction("BaskanIndex");
                }
                else
                {
                    ViewBag.Bolumler = new SelectList(_context.Bolumler.Where(b => b.BolumBaskani == "Seçiniz").ToList(), "Id", "BolumAd");
                    ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                    return View(model);
                }
            }
            else
            {

                ViewBag.Bolumler = new SelectList(_context.Bolumler.Where(b => b.BolumBaskani == "Seçiniz").ToList(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAdSoyad");
                return View(model);
            }
        }

        public async Task<IActionResult> DanismanIndex(int id)
        {
            var ogrenci = await _context.Ogrenciler.ToListAsync();
            return View(ogrenci);
        }
        public async Task<IActionResult> DanismanAtaGuncelle(int id)
        {
            if (id == 0)
            {

                ViewBag.Ogrenci = new SelectList(_context.Ogrenciler.Where(d => d.OgrenciDanisman == null).ToList(), "Id", "OgrenciAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View();
            }
            else
            {
                ViewBag.Ogrenci = new SelectList(_context.Ogrenciler.Where(x => x.Id == id), "Id", "OgrenciAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DanismanAtaGuncelle(Ogrencis model, int id, int modal, string ogretmenAdSoyad)
        {
            if (modal != 0)
            {
                var deneme = _context.Ogrenciler.FirstOrDefault(b => b.Id == modal);
                if (deneme != null)
                {
                    deneme.OgrenciDanisman = ogretmenAdSoyad;
                    _context.Ogrenciler.Update(deneme);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "İşlem Başarılı!";
                    return RedirectToAction("Index", "Ogrenci");
                }

            }

                var ogrenci = _context.Ogrenciler.FirstOrDefault(a => a.Id == id);

                if (ogrenci != null)
                {
                    ogrenci.OgrenciDanisman = model.OgrenciDanisman;
                    _context.Ogrenciler.Update(ogrenci);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "İşlem Başarılı!";
                    return RedirectToAction("DanismanIndex");
                }
                else
                {
                    ViewBag.Ogrenci = new SelectList(_context.Ogrenciler.ToList(), "Id", "OgrenciAd");
                    ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenAdSoyad", "OgretmenAdSoyad");
                    return View(model);
                }

            }
        }

    }


