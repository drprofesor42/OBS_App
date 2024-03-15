using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Areas.Ogrenci.Controllers
{
	public class DersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
