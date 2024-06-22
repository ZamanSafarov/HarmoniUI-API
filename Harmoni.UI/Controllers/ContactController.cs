using Harmoni.UI.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Harmoni.UI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Contact([FromBody] ContactDTO model)
		{
			var client = new HttpClient();
				

					// Serialize ContactViewModel to JSON
					var jsonContent = JsonConvert.SerializeObject(model);
					var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

					// Send POST request to API
					var response = await client.PostAsync("https://localhost:7222/api/contacts", stringContent);

					// Handle response
					if (response.IsSuccessStatusCode)
					{
						var apiResponse = await response.Content.ReadAsStringAsync();
						var successMessage = JsonConvert.DeserializeAnonymousType(apiResponse, new { message = "" });
						return Ok();
					}
					else
					{
						var errorMessage = await response.Content.ReadAsStringAsync();
						return StatusCode(StatusCodes.Status400BadRequest);
					}
				
			
		}
	}
}
