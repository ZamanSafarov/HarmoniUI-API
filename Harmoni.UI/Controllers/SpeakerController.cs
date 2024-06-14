using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
    public class SpeakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
