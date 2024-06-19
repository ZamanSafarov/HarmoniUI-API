
using Harmoni.UI.DTOs;
using Harmoni.UI.DTOs.About;
using Harmoni.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Harmoni.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class AboutController : Controller
{
    #region Award
    public async Task<IActionResult> Award(string encryptedParams)
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
        var response = await client.GetAsync($"https://localhost:7222/api/Awards");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var awards = JsonConvert.DeserializeObject<List<AwardGetDTO>>(content);

        var query = awards.AsQueryable();
        var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);
        ViewData["Title"] = "Award";
        return View(pagedList);
    }
    public async Task<IActionResult> ArchiveAward(string encryptedParams)
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
        var response = await client.GetAsync($"https://localhost:7222/api/Awards/GetAllArchive");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var awards = JsonConvert.DeserializeObject<List<AwardGetDTO>>(content);

        var query = awards.AsQueryable();
        var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);

        return View(pagedList);
    }

    public async Task<IActionResult> CreateAward()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAward(AwardCreateDTO awardDTO)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        HttpClient client = new HttpClient();
        var response = await client.PostAsJsonAsync<AwardCreateDTO>("https://localhost:7222/api/Awards", awardDTO);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Award");
    }
    public async Task<IActionResult> HardDeleteAward(int id)
    {
        HttpClient client = new HttpClient();
        var result = await client.DeleteAsync($"https://localhost:7222/api/Awards/hardDelete/{id}");
        if (result.IsSuccessStatusCode)
        {
            return RedirectToAction("Award");
        }
        else
        {
            return BadRequest(result);
        }

    }
    public async Task<IActionResult> DeleteAward(int id)
    {
        HttpClient client = new HttpClient();
        var result = await client.DeleteAsync($"https://localhost:7222/api/Awards/{id}");
        if (result.IsSuccessStatusCode)
        {
            return RedirectToAction("Award");
        }
        else
        {
            return BadRequest(result);
        }

    }
    public async Task<IActionResult> RecoverAward(int id, EntityRecoverDTO recoverDTO)
    {
        HttpClient client = new HttpClient();
        var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/Awards/Recover/{id}", recoverDTO);
        return RedirectToAction("Award");
    }
    public async Task<IActionResult> UpdateAward(int id)
    {

        HttpClient client = new HttpClient();
        var data = await client.GetFromJsonAsync<AwardUpdateDTO>($"https://localhost:7222/api/Awards/{id}");

        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAward(int id, AwardUpdateDTO updateDTO)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        HttpClient client = new HttpClient();
        var result = await client.PutAsJsonAsync<AwardUpdateDTO>($"https://localhost:7222/api/Awards/{id}", updateDTO);
        return RedirectToAction("Award");
    }
    #endregion


    #region Advantages
    public async Task<IActionResult> Advantage(string encryptedParams)
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
        var response = await client.GetAsync($"https://localhost:7222/api/Advantages");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var advantages = JsonConvert.DeserializeObject<List<AdvantageGetDTO>>(content);

        var query = advantages.AsQueryable();
        var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);
        ViewData["Title"] = "Advantage";
        return View(pagedList);
    }
    public async Task<IActionResult> ArchiveAdvantage(string encryptedParams)
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
        var response = await client.GetAsync($"https://localhost:7222/api/Advantages/GetAllArchive");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var advantages = JsonConvert.DeserializeObject<List<AdvantageGetDTO>>(content);

        var query = advantages.AsQueryable();
        var pagedList = await query.ToPagedListAsync(pageIndex, pageSize);

        return View(pagedList);
    }

    public async Task<IActionResult> CreateAdvantage()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAdvantage(AdvantageCreateDTO advantageDTO)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        HttpClient client = new HttpClient();
        var response = await client.PostAsJsonAsync<AdvantageCreateDTO>("https://localhost:7222/api/Advantages", advantageDTO);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Advantage");
    }
    public async Task<IActionResult> HardDeleteAdvantage(int id)
    {
        HttpClient client = new HttpClient();
        var result = await client.DeleteAsync($"https://localhost:7222/api/Advantages/hardDelete/{id}");
        if (result.IsSuccessStatusCode)
        {
            return RedirectToAction("Advantage");
        }
        else
        {
            return BadRequest(result);
        }

    }
    public async Task<IActionResult> DeleteAdvantage(int id)
    {
        HttpClient client = new HttpClient();
        var result = await client.DeleteAsync($"https://localhost:7222/api/Advantages/{id}");
        if (result.IsSuccessStatusCode)
        {
            return RedirectToAction("Advantage");
        }
        else
        {
            return BadRequest(result);
        }

    }
    public async Task<IActionResult> RecoverAdvantage(int id, EntityRecoverDTO recoverDTO)
    {
        HttpClient client = new HttpClient();
        var result = await client.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/Advantages/Recover/{id}", recoverDTO);
        return RedirectToAction("Advantage");
    }
    public async Task<IActionResult> UpdateAdvantage(int id)
    {

        HttpClient client = new HttpClient();
        var data = await client.GetFromJsonAsync<AdvantageUpdateDTO>($"https://localhost:7222/api/Advantages/{id}");

        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAdvantage(int id, AdvantageUpdateDTO updateDTO)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        HttpClient client = new HttpClient();
        var result = await client.PutAsJsonAsync<AdvantageUpdateDTO>($"https://localhost:7222/api/Advantages/{id}", updateDTO);
        return RedirectToAction("Advantage");
    }
    #endregion
}