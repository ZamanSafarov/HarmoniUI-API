using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
