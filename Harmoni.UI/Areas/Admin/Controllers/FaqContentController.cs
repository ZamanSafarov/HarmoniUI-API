using Harmoni.UI.Helpers;
using Harmoni.Ui.DTOs;
using Harmoni.UI.DTOs;
using Harmoni.UI.DTOs.FAQ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using X.PagedList;
using Harmoni.UI.DTOs.Event;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FaqContentController : Controller
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
            var response = await client.GetAsync($"https://localhost:7222/api/FAQContents");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var faqs = JsonConvert.DeserializeObject<List<FAQContentGetDTO>>(content);

            var query = faqs.AsQueryable();
            var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);

            return View(pagedList);

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
            var response = await client.GetAsync($"https://localhost:7222/api/FAQContents/GetAllArchive");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var faqs = JsonConvert.DeserializeObject<List<FAQContentGetDTO>>(content);

            var query = faqs.AsQueryable();
            var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);

            return View(pagedList);
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7222/api/Events");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<EventGetDTO>>(content);
         
            ViewBag.Events = events;
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FAQContentCreateDTO faqDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(faqDTO), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7222/api/FAQContents", content);

			//response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
			}
			else
			{
				var customResponse = await response.Content.ReadAsAsync<CustomResponse>();
				if (response.StatusCode == (HttpStatusCode)customResponse.Code)
				{
					ViewBag.Message = customResponse.Message;
					return View();
				}
			}

            return RedirectToAction("Index");


        }
        public async Task<IActionResult> HardDelete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync($"https://localhost:7222/api/FAQContents/hardDelete/{id}");
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
            var result = await client.DeleteAsync($"https://localhost:7222/api/FAQContents/{id}");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(result);
            }

        }
        public async Task<IActionResult> Recover(int id, EntityRecoverDTO recoverDTO)
        {
            HttpClient client = new HttpClient();
            var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/FAQContents/Recover/{id}", recoverDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {

            HttpClient client = new HttpClient();
            var data = await client.GetFromJsonAsync<FAQContentUpdateDTO>($"https://localhost:7222/api/FAQContents/{id}");
            var response = await client.GetAsync($"https://localhost:7222/api/Events");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<EventGetDTO>>(content);

            ViewBag.Events = events;

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FAQContentUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateDTO), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7222/api/FAQContents/{id}", content);


            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var customResponse = await response.Content.ReadAsAsync<CustomResponse>();
                if (response.StatusCode == (HttpStatusCode)customResponse.Code)
                {
                    ViewBag.Message = customResponse.Message;
                    return View();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
