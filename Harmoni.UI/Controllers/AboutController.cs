
using Harmoni.UI.DTOs.About;
using Harmoni.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harmoni.UI.Controllers
{
	public class AboutController : Controller
	{
        
		public async Task<IActionResult> Index()
		{
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7222/api/Awards");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var awards = JsonConvert.DeserializeObject<List<AwardGetDTO>>(content);

            var response2 = await client.GetAsync($"https://localhost:7222/api/Advantages");
            response2.EnsureSuccessStatusCode();

            var content2 = await response2.Content.ReadAsStringAsync();
            var advantages = JsonConvert.DeserializeObject<List<AdvantageGetDTO>>(content2);

            AboutViewModel viewModel = new AboutViewModel() { 
            advantageGetDTOs = advantages,
            awardGetDTOs = awards
            };

            return View(viewModel);
        }

    }
}
