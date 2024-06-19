using Harmoni.UI.DTOs.Speaker;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harmoni.UI.ViewComponents
{
	public class SpeakerViewComponent:ViewComponent
	{
		private readonly HttpClient _httpClient;
        public SpeakerViewComponent(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var response = await _httpClient.GetAsync($"https://localhost:7222/api/Speakers");
			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var speakers = JsonConvert.DeserializeObject<List<SpeakerGetDTO>>(content);
			return View(speakers);
		}
	}
}
