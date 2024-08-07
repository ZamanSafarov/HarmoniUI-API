﻿using Harmoni.UI.Helpers;
using Harmoni.UI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SettingController : Controller
    {
        public async Task<IActionResult> Index(string encryptedParams)
		{
            int pageIndex = 1;
            int pageSize = 3;

            if (!string.IsNullOrEmpty(encryptedParams))
            {
                try
                {
                    string decryptedParams = EncryptionHelper.Decrypt(encryptedParams);
                    var parameters = decryptedParams.Split(';');
                    pageIndex = int.Parse(parameters[0]);
                    pageSize = int.Parse(parameters[1]);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // Optionally, return an error view or default values
                    return BadRequest("Invalid encrypted parameters.");
                }
            }

                HttpClient client = new HttpClient();
                var data = await client.GetFromJsonAsync<List<SettingGetDTO>>($"https://localhost:7222/api/Settings");
                var query = data.AsQueryable();
                return View(await query.ToPagedListAsync(pageIndex, pageSize));
           
		}
        public async Task<IActionResult> Archive(string encryptedParams)
        {
            int pageIndex = 1;
            int pageSize = 3;

            if (!string.IsNullOrEmpty(encryptedParams))
            {
                try
                {
                    string decryptedParams = EncryptionHelper.Decrypt(encryptedParams);
                    var parameters = decryptedParams.Split(';');
                    pageIndex = int.Parse(parameters[0]);
                    pageSize = int.Parse(parameters[1]);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // Optionally, return an error view or default values
                    return BadRequest("Invalid encrypted parameters.");
                }
            }

            HttpClient client = new HttpClient();
            var data = await client.GetFromJsonAsync<List<SettingGetDTO>>($"https://localhost:7222/api/Settings/GetAllArchive");
            var query = data.AsQueryable();
            return View(await query.ToPagedListAsync(pageIndex, pageSize));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SettingCreateDTO settingDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
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
                return NotFound();
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
                return NotFound();
            }

        }
        public async Task<IActionResult> Recover(int id, EntityRecoverDTO recoverDTO)
        {
            HttpClient client = new HttpClient();
            var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/Settings/Recover/{id}", recoverDTO);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
		public async Task<IActionResult> Update(int id)
		{

			HttpClient client = new HttpClient();
			var response = await client.GetAsync($"https://localhost:7222/api/Settings/{id}");
          
            var content = await response.Content.ReadAsStringAsync();
            var setting = JsonConvert.DeserializeObject<SettingUpdateDTO>(content);
            if (response.IsSuccessStatusCode)
            {
                return View(setting);
            }
            else
            {
                return NotFound();
            }

        }

		[HttpPost]
		public async Task<IActionResult> Update(int id, SettingUpdateDTO updateDTO)
		{
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpClient client = new HttpClient();
			var result = await client.PutAsJsonAsync<SettingUpdateDTO>($"https://localhost:7222/api/Settings/{id}", updateDTO);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

	}
}
