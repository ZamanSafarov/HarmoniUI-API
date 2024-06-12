using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
