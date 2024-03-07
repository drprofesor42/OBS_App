using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BolumController : Controller
    {
        private readonly IdentityDataContext _context;



        public BolumController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {

            var bolums = await _context.Bolumler.ToListAsync();
            return View(bolums);
        }

        public  IActionResult Ekle_Guncelle()
        {

            return View();
        }

        public IActionResult Sil()
        {
            return View();
        }

    }
}
