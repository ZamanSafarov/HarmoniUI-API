
using Harmoni.UI.DTOs;
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

		public async Task<Dictionary<string, string>> GetSettingAsync()
		{
			HttpClient client = new HttpClient();
			var data = await client.GetFromJsonAsync<List<SettingGetDTO>>($"https://localhost:7222/api/Settings");
			var setting = data.ToDictionary(s => s.Key, s => s.Value);
			return setting;
		}

	}
}
