using Harmoni.UI.DTOs.Gallery;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Controllers
{
	public class GalleryController : Controller
	{
        private readonly HttpClient _httpClient;

        public GalleryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
		public async Task<IActionResult> Index()
		{
			var galleryItems = await _httpClient.GetFromJsonAsync<IEnumerable<GalleryGetDTO>>($"https://localhost:7222/api/galleries??type=all&page=1");
			return View(galleryItems);
		}

		[HttpGet]
		public async Task<IActionResult> GetGalleryItems(string type = "all", int page = 1)
		{
			var response = await _httpClient.GetFromJsonAsync<IEnumerable<GalleryGetDTO>>($"https://localhost:7222/api/galleries?type={type}&page={page}");
			return Json(response);
		}
	}
}
