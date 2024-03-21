using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    [Authorize(Roles = "Ogretmen")]
    public class DuyuruController : BaseController
    {
        private readonly IdentityDataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DuyuruController(UserManager<AppUser> userManager, IdentityDataContext context) : base(userManager, context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var duyurular = _context.Duyurular.Include(x => x.Ogretmens).ToList();
			var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                ViewBag.kullanıcıId = ogretmen.Id;

			}

            return View(duyurular);
        }

        public async Task<IActionResult> Ekle_Guncelle(int id)
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
            {
                var ogretmen = _context.Ogretmenler.FirstOrDefault(x => x.OgretmenEposta == kullanıcı.Email);
                if (id == 0)
                {
			        var model = new Duyuru
			        {
				        OgretmensId = ogretmen.Id,
			        };
                    return View(model);
                
                }
                else
                {
                    var duyuru = await _context.Duyurular.FirstOrDefaultAsync(x => x.Id == id);
                    
                    if (duyuru == null)
                    {
                        // Hata Gönder
                        return RedirectToAction("Index");
                    }
                    else if(duyuru.OgretmensId != ogretmen.Id)
                    {
                        // Kendine ait olamayan mesajı değiştirmeye çalışıyor. Hata
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(duyuru);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index");
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
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Duyurular.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("Index");
                }
            }


            return View(model);
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
