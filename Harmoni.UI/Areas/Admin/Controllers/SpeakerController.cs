using Harmoni.UI.Helpers;
using Harmoni.UI.DTOs;
using Harmoni.UI.DTOs.Speaker;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Harmoni.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakerController : Controller
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
            var data = await client.GetFromJsonAsync<List<SpeakerGetDTO>>($"https://localhost:7222/api/Speakers");
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
            var data = await client.GetFromJsonAsync<List<SpeakerGetDTO>>($"https://localhost:7222/api/Speakers/GetAllArchive");
            var query = data.AsQueryable();
            return View(await query.ToPagedListAsync(pageIndex, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SpeakerCreateDTO speakerDto)
        {
            if(speakerDto.FormFile == null)
            {
                ViewBag.FormMessage = "File Can not be null";
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(speakerDto.Name), "Name");
                    content.Add(new StringContent(speakerDto.Description), "Description");
                    content.Add(new StringContent(speakerDto.Experience.ToString()), "Experience");
                    if (!string.IsNullOrEmpty(speakerDto.FacebookUrl))
                    {
                        content.Add(new StringContent(speakerDto.FacebookUrl), "FacebookUrl");
                    }
                    if (!string.IsNullOrEmpty(speakerDto.InstagramUrl))
                    {
                        content.Add(new StringContent(speakerDto.InstagramUrl), "InstagramUrl");
                    }
                    if (!string.IsNullOrEmpty(speakerDto.XUrl))
                    {
                        content.Add(new StringContent(speakerDto.XUrl), "XUrl");
                    }
                    if (!string.IsNullOrEmpty(speakerDto.TwitchUrl))
                    {
                        content.Add(new StringContent(speakerDto.TwitchUrl), "TwitchUrl");
                    }

                    if (speakerDto.FormFile != null)
                    {
                        var fileContent = new StreamContent(speakerDto.FormFile.OpenReadStream());
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                        {
                            Name = "FormFile",
                            FileName = speakerDto.FormFile.FileName
                        };
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(speakerDto.FormFile.ContentType);
                        content.Add(fileContent);
                    }
                  

                    var result = await client.PostAsync("https://localhost:7222/api/Speakers", content);


                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var errorContent = await result.Content.ReadAsStringAsync();
                        return BadRequest(errorContent);
                    }
                }
            }

        }
        public async Task<IActionResult> HardDelete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync($"https://localhost:7222/api/Speakers/hardDelete/{id}");
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
            var result = await client.DeleteAsync($"https://localhost:7222/api/Speakers/{id}");
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
            var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/Speakers/Recover/{id}", recoverDTO);
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
            var response = await client.GetAsync($"https://localhost:7222/api/Speakers/{id}");

            var content = await response.Content.ReadAsStringAsync();
            var speaker = JsonConvert.DeserializeObject<SpeakerGetDTO>(content);
           var speakerUpdate = new SpeakerUpdateDTO();

            speakerUpdate.XUrl = speaker.XUrl;
            speakerUpdate.InstagramUrl = speaker.InstagramUrl;
            speakerUpdate.FacebookUrl = speaker.FacebookUrl;
            speakerUpdate.TwitchUrl = speaker.TwitchUrl;
            speakerUpdate.Experience = speaker.Experience;
            speakerUpdate.Description = speaker.Description;
            speakerUpdate.Name= speaker.Name;


            if (response.IsSuccessStatusCode)
            {
                return View(speakerUpdate);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [FromForm]SpeakerUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(updateDTO.Name), "Name");
                    content.Add(new StringContent(updateDTO.Description), "Description");
                    content.Add(new StringContent(updateDTO.Experience.ToString()), "Experience");

                    if (!string.IsNullOrEmpty(updateDTO.FacebookUrl))
                    {
                        content.Add(new StringContent(updateDTO.FacebookUrl), "FacebookUrl");
                    }
                    if (!string.IsNullOrEmpty(updateDTO.InstagramUrl))
                    {
                        content.Add(new StringContent(updateDTO.InstagramUrl), "InstagramUrl");
                    }
                    if (!string.IsNullOrEmpty(updateDTO.XUrl))
                    {
                        content.Add(new StringContent(updateDTO.XUrl), "XUrl");
                    }
                    if (!string.IsNullOrEmpty(updateDTO.TwitchUrl))
                    {
                        content.Add(new StringContent(updateDTO.TwitchUrl), "TwitchUrl");
                    }

                    if (updateDTO.FormFile != null)
                    {
                        var fileContent = new StreamContent(updateDTO.FormFile.OpenReadStream());
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                        {
                            Name = "FormFile",
                            FileName = updateDTO.FormFile.FileName
                        };
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(updateDTO.FormFile.ContentType);
                        content.Add(fileContent);
                    }

                    var result = await client.PutAsync($"https://localhost:7222/api/Speakers/{id}", content);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var errorContent = await result.Content.ReadAsStringAsync();
                        return BadRequest(errorContent);
                    }
                }
            }
        }
    }
}
