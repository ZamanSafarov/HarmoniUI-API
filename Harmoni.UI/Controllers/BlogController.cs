using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
