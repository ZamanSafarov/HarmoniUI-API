using Harmoni.UI.DTOs;
using Harmoni.UI.DTOs.Gallery;
using Harmoni.UI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Area("Admin")]

public class GalleryController : Controller
{
	private readonly HttpClient _httpClient;

	public GalleryController(HttpClient httpClient, IWebHostEnvironment env)
	{
		_httpClient = httpClient;
	}

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
        var galleryItems = await _httpClient.GetFromJsonAsync<List<GalleryGetDTO>>("https://localhost:7222/api/Galleries");
        var query = galleryItems.AsQueryable();
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
        var galleryItems = await _httpClient.GetFromJsonAsync<List<GalleryGetDTO>>("https://localhost:7222/api/Galleries/GetAllArchive");
        var query = galleryItems.AsQueryable();
        return View(await query.ToPagedListAsync(pageIndex, pageSize));
    }

    public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(GalleryCreateDTO itemDto)
	{
		if (ModelState.IsValid)
		{
			using (var content = new MultipartFormDataContent())
			{
				content.Add(new StringContent(itemDto.Title), nameof(itemDto.Title));
				content.Add(new StringContent(itemDto.FestivalName), nameof(itemDto.FestivalName));
				content.Add(new StringContent(itemDto.Date.ToString("o")), nameof(itemDto.Date));

				if (itemDto.File != null)
				{
					var fileContent = new StreamContent(itemDto.File.OpenReadStream());
					fileContent.Headers.ContentType = new MediaTypeHeaderValue(itemDto.File.ContentType);
					content.Add(fileContent, nameof(itemDto.File), itemDto.File.FileName);
				}

				var response = await _httpClient.PostAsync("https://localhost:7222/api/galleries", content);
				response.EnsureSuccessStatusCode();
				return RedirectToAction(nameof(Index));
			}
		}
		return View(itemDto);
	}

	public async Task<IActionResult> Update(int id)
	{
		var galleryItem = await _httpClient.GetFromJsonAsync<GalleryGetDTO>($"https://localhost:7222/api/galleries/{id}");
        if (galleryItem == null)
        {
            return NotFound();
        }
        var updateDto = new GalleryUpdateDTO();
		updateDto.Title = galleryItem.Title;
		updateDto.FestivalName = galleryItem.FestivalName;
		updateDto.Date = galleryItem.Date;
       
		return View(updateDto);
	}

	[HttpPost]
	public async Task<IActionResult> Update(GalleryUpdateDTO itemDto)
	{
		if (ModelState.IsValid)
		{
			using (var content = new MultipartFormDataContent())
			{
				content.Add(new StringContent(itemDto.Id.ToString()), nameof(itemDto.Id));
				content.Add(new StringContent(itemDto.Title), nameof(itemDto.Title));
				content.Add(new StringContent(itemDto.FestivalName), nameof(itemDto.FestivalName));
				content.Add(new StringContent(itemDto.Date.ToString("o")), nameof(itemDto.Date));

				if (itemDto.File != null)
				{
					var fileContent = new StreamContent(itemDto.File.OpenReadStream());
					fileContent.Headers.ContentType = new MediaTypeHeaderValue(itemDto.File.ContentType);
					content.Add(fileContent, nameof(itemDto.File), itemDto.File.FileName);
				}

				var response = await _httpClient.PutAsync($"https://localhost:7222/api/galleries/{itemDto.Id}", content);
				response.EnsureSuccessStatusCode();
				return RedirectToAction(nameof(Index));
			}
		}
		return View(itemDto);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var response = await _httpClient.DeleteAsync($"https://localhost:7222/api/galleries/hardDelete/{id}");
		if (response.IsSuccessStatusCode)
		{
			return RedirectToAction(nameof(Index));
		}
		return NotFound();
	}

	public async Task<IActionResult> SoftDelete(int id)
	{
		var response = await _httpClient.DeleteAsync($"https://localhost:7222/api/galleries/{id}");
		if (response.IsSuccessStatusCode)
		{
			return RedirectToAction(nameof(Index));
		}
		return NotFound();
	}

	public async Task<IActionResult> Recover(int id, EntityRecoverDTO recoverDTO)
	{
		var response = await _httpClient.PutAsJsonAsync<EntityRecoverDTO>($"https://localhost:7222/api/galleries/Recover/{id}", recoverDTO);
		if (response.IsSuccessStatusCode)
		{
			return RedirectToAction(nameof(Index));
		}
		return NotFound();
	}
}
