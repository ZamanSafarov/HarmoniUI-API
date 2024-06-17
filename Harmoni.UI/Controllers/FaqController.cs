using Harmoni.UI.DTOs.FAQ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harmoni.UI.Controllers
{
	public class FaqController : Controller
	{

		public async Task<IActionResult> Index()
		{
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7222/api/FAQContents");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var faqs = JsonConvert.DeserializeObject<List<FAQContentGetDTO>>(content);
            return View(faqs);
		}
	}
}
