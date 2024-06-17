using Harmoni.UI.DTOs.Speaker;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harmoni.UI.Controllers
{
    public class SpeakerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7222/api/Speakers");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var speakers = JsonConvert.DeserializeObject<List<SpeakerGetDTO>>(content);
            return View(speakers);
        }
    }
}
