using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OBS_App.Models;

namespace OBS_App.Controllers.Admin
{
    
    public class UsersController : Controller
    {
       

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Ekle()
		{
			return View();
		}

		public IActionResult Sil()
		{
			return View();
		}

		public IActionResult Guncelle()
		{
			return View();
		}

		public IActionResult DersAta()
		{
			return View();
		}

		public IActionResult DersSil()
		{
			return View();
		}

		public IActionResult BolumAta()
		{
			return View();
		}

		public IActionResult BolumSil()
		{
			return View();
		}
	}
}
