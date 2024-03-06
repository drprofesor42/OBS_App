using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;


namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _context;
        public OgrenciController(IdentityDataContext context)
        {

            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public IActionResult Ekle_Guncelle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model)
        {
            if (ModelState.IsValid)
            {
                await _context.Ogrenciler.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Sil()
        {
            return View();
        }

        public IActionResult DersAta_Sil()
        {
            return View();
        }

        public IActionResult BolumAta_Sil()
        {
            return View();
        }

    }
}
