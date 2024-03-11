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
	public class BolumController : Controller
	{
		private readonly IdentityDataContext _context;

		public BolumController(IdentityDataContext context)
		{
			_context = context;

		}
		public IActionResult Index()
		{
			var bolum =_context.Bolumler.ToList();
			return View(bolum);
		}

		public async Task<IActionResult> Ekle_Guncelle(int id)
		{
			if (id == 0)
			{
                ViewBag.Fakulteler = new SelectList(await _context.Fakulteler.ToListAsync(),"Id", "FakulteAd");
                return View();

			}
			else
			{
				var bolum = await _context.Bolumler.FirstOrDefaultAsync(x => x.Id == id);
				return View(bolum);

			}

		}
		[HttpPost]
		public async Task<IActionResult> Ekle_Guncelle(Bolum model, int Kaydet)
		{
			if (ModelState.IsValid)
			{
				//Ekleme İşlemi
				if (Kaydet == 1)
				{

					await _context.Bolumler.AddAsync(model);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				//Güncelleme İşlemi
				else if (Kaydet == 2)
				{
					_context.Bolumler.Update(model);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					//Hata mesajı verip model gönderecek
					return View(model);
				}
			}
			else
			{
				return View(model);
			}
		}
		public async Task<IActionResult> Sil(int? id)
		{
			if (id == null)
			{
				//Hata mesajı bolum bulunamadı
				return RedirectToAction("Index");
			}
			else
			{
				var bolum = await _context.Bolumler.FirstOrDefaultAsync(x => x.Id == id);

				if (bolum != null)
				{
					_context.Bolumler.Remove(bolum);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					return RedirectToAction("Index");
				}

			}


		}

	}
}
