using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class FaqController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
