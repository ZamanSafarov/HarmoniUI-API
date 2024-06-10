
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Harmoni.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
