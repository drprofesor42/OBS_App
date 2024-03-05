using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OBS_App.Controllers
{
	public class OgrenciController : Controller
	{

        [Authorize(Roles = "Ogrenci")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
