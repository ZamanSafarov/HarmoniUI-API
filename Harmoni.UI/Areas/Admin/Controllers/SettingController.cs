using Harmoni.UI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SettingController : Controller
    {
        public async Task<IActionResult> Index(int pageSize =1 ,int pageIndex =2)
        {
            HttpClient client = new HttpClient();
            var data = await client.GetFromJsonAsync<List<SettingGetDTO>>($"https://localhost:7222/api/Settings");
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SettingCreateDTO settingDto)
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync<SettingCreateDTO>("https://localhost:7222/api/Settings", settingDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(result);
            }
          
        }
        public async Task<IActionResult> HardDelete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync($"https://localhost:7222/api/Settings/hardDelete/{id}");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(result);
            }

        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync($"https://localhost:7222/api/Settings/{id}");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(result);
            }

        }
		public async Task<IActionResult> Update(int id)
		{

			HttpClient client = new HttpClient();
			var data = await client.GetFromJsonAsync<SettingUpdateDTO>($"https://localhost:7222/api/Settings/{id}");

			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, SettingUpdateDTO updateDTO)
		{
			HttpClient client = new HttpClient();
			var result = await client.PutAsJsonAsync<SettingUpdateDTO>($"https://localhost:7222/api/Settings/{id}", updateDTO);
			return RedirectToAction("Index");
		}

	}
}
