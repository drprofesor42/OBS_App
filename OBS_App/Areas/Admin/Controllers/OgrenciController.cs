using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OgrenciController : Controller
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public OgrenciController(IdentityDataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public async Task<IActionResult> Ekle_Guncelle(int? id)
        {
            if (id == 0)
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd" );
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                return View();
            }
            else
            {
                ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                var ogrenci = _context.Ogrenciler.Include(o => o.OgrenciAdres).FirstOrDefault(x => x.Id == id);
                if (ogrenci == null)
                {
                    return NotFound();
                }
                return View(ogrenci);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogrencis model, string type)
        {
   
            if (ModelState.IsValid)
            {
                if (model == null || type == null)
                {
                    ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
                    ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
                    // TempData Hata Gönder
                    return View(model);
                }
                else if (type == "0")
                {
					var user = new AppUser
					{
						UserName = model.OgrenciEposta,
						Email = model.OgrenciEposta,
					};

                    IdentityResult result = await _userManager.CreateAsync(user, model.OgrenciParola);

					_context.Add(model);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else if (type == "1")
                {
                   
                    _context.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Bolum = new SelectList(await _context.Bolumler.ToListAsync(), "Id", "BolumAd");
            ViewBag.Ogretmen = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "OgretmenAd");
            return View(model);
        }

        // id ye göre db'den kayıt siliyor
        public IActionResult Sil(int id)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(x => x.Id == id);
            if (ogrenci == null)
            {
                // TempData Hata Gönder
                return RedirectToAction("Index");
            }
            else
            {
                _context.Remove(ogrenci);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
