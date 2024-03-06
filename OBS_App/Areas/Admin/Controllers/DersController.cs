using Microsoft.AspNetCore.Mvc;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DersController : Controller
    {
        private readonly IdentityDataContext _identityDataContext;

        public DersController(IdentityDataContext identityDataContext)
        {
            _identityDataContext = identityDataContext;
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
        public IActionResult Ekle_Guncelle(Ders model, string type)
        {
            if (model == null)
            {
                Console.WriteLine("HATA No:1");
                return RedirectToAction("Index");
            }
            else if (type == "0")
            {
                Console.WriteLine("Ders Ekle");
                _identityDataContext.Add(model);
                _identityDataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else if (type == "1")
            {
                Console.WriteLine("Ders Güncelle");


				return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine(type);
                Console.WriteLine("How it possible");
                Console.WriteLine("How it possible");
                Console.WriteLine("How it possible");
                Console.WriteLine("How it possible");
                return RedirectToAction("Index");
			}

        }

        public IActionResult Sil()
        {
            return View();
        }
    }
}
