using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
