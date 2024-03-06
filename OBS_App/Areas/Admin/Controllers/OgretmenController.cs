using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using OBS_App.Data;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OgretmenController : Controller
    {


        private readonly IdentityDataContext _context;
        public OgretmenController(IdentityDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Ekle_Guncelle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle_Guncelle(Ogretmens model)
        {
            if (ModelState.IsValid)
            {
                await _context.Ogretmenler.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Sil()
        {
            return View();
        }

    }
}
