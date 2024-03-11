using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DuyuruController : Controller
    {
        private readonly IdentityDataContext _context;
        public DuyuruController(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var duyurular = _context.Duyurular.ToList();
            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {

			if (id == 0)
            {
                return View();
            }
            else
            {
                var duyuru = await _context.Duyurular.FirstOrDefaultAsync(x => x.Id == id);
                if (duyuru == null)
                {
                    // Hata Gönder
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(duyuru);
                }
            }
        }

        [HttpPost]
		public async Task<IActionResult> Ekle_Guncelle(string type, Duyuru model)
		{
            if (ModelState.IsValid)
            {
				if (type == "0")
				{
					await _context.Duyurular.AddAsync(model);
					await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
				}
				else
				{
					_context.Duyurular.Update(model);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
			}
            

			return View (model);
		}

		public IActionResult Sil(int id)
        {
            var duyuru = _context.Duyurular.FirstOrDefault(x => x.Id == id);
            if (duyuru == null)
            {
                // Hata gönder
            }
            else
            {
                _context.Remove(duyuru);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
