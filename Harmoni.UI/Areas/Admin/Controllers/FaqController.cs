
using Harmoni.UI.Helpers;
using Harmoni.UI.DTOs;
using Harmoni.UI.DTOs.FAQ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FaqController : Controller
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
            var response = await client.GetAsync($"https://localhost:7222/api/FAQs");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var faqs = JsonConvert.DeserializeObject<List<FAQGetDTO>>(content);

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
            var response = await client.GetAsync($"https://localhost:7222/api/FAQs/GetAllArchive");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var faqs = JsonConvert.DeserializeObject<List<FAQGetDTO>>(content);

            var query = faqs.AsQueryable();
            var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);

            return View(pagedList);
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7222/api/FAQContents");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var fAQContents = JsonConvert.DeserializeObject<List<FAQContentGetDTO>>(content);
            if (fAQContents is null)
            {
                ViewBag.Message = "Please select Faq Conent or Create one!";
            }
            else
            {
                ViewBag.FAQContents = fAQContents;
            }
           

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FAQCreateDTO faqDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(faqDTO), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7222/api/FAQs", content);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> HardDelete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync($"https://localhost:7222/api/FAQs/hardDelete/{id}");
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
            var result = await client.DeleteAsync($"https://localhost:7222/api/FAQs/{id}");
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
            var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/FAQs/Recover/{id}", recoverDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {

            HttpClient client = new HttpClient();
            var data = await client.GetFromJsonAsync<FAQGetDTO>($"https://localhost:7222/api/FAQs/{id}");

            var update = new FAQUpdateDTO();

            update.Question = data.Question;
            update.Answer = data.Answer;
            update.FAQContentId = data.FAQContent.Id;

            var response = await client.GetAsync($"https://localhost:7222/api/FAQContents");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var fAQContents = JsonConvert.DeserializeObject<List<FAQContentGetDTO>>(content);

            ViewBag.FAQContents = fAQContents;
            return View(update);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FAQUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpClient client = new HttpClient();
            var result = await client.PutAsJsonAsync<FAQUpdateDTO>($"https://localhost:7222/api/FAQs/{id}", updateDTO);
            return RedirectToAction("Index");
        }
    }
   
}
