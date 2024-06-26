﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class DersController : Controller
    {
            private readonly IdentityDataContext _context;
            private readonly UserManager<AppUser> _userManager;

            public DersController(IdentityDataContext context, UserManager<AppUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Derslerim()
		{
			var kullanıcı = await _userManager.GetUserAsync(User);
            if (kullanıcı != null)
			{
				// Kullanıcının derslerini çek
				var ogrenci =  _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
                var dersIdler = _context.DersOgrenciler.Where(x => x.OgrencisId == ogrenci.Id).ToList();
                //var dersler = _context.Dersler.Where(z => z.Id == dersIdler.)
                
                
                // ViewsModel Gönderilecek!!

				return View();
			}

			// Hata Gönder
			return View();
		}

		public IActionResult DersProgramı()
        {
            return View();
        }

        public async Task<IActionResult> SınavSonuc()
        {
            var kullanıcı = await _userManager.GetUserAsync(User);
			if (kullanıcı != null)
			{
				// Kullanıcının derslerini çek
				var ogrenci = _context.Ogrenciler.FirstOrDefault(d => d.OgrenciEposta == kullanıcı.Email);
				var dersler = _context.DersOgrenciler.Where(x => x.OgrencisId == ogrenci.Id).ToList();

				return View(dersler);
			}

            // Hata Gönder
			return View();
        }

        public IActionResult SınavTakvim()
        {
            return View();
        }

    }
}
