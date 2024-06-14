using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class EventController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Detail()
		{
            return View();
        }
		public IActionResult Booking()
		{
			return View();
		}
	}
}
