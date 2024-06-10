using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class GalleryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
