using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class ServiceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
