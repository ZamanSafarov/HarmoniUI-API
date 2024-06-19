using Harmoni.Business.Common;
using Harmoni.Business.DTOs;
using Harmoni.Business.Exceptions;
using Harmoni.Business.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpeakersController : ControllerBase
	{
		private readonly ISpeakerService _service;

        public SpeakersController(ISpeakerService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_service.GetSpeaker(x => x.Id == id && x.IsDeleted == false) is null)
            {
                return NotFound();
            }
            return Ok(_service.GetSpeaker(x => x.Id == id && x.IsDeleted == false));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllSpeakers(x => x.IsDeleted == false));
        }

        [HttpGet("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            return Ok(_service.GetAllSpeakers(x => x.IsDeleted == true));
        }

        [HttpPost]
        public IActionResult Create([FromForm]SpeakerCreateDTO createDTO)
        {
            
            try
            {
                _service.AddSpeaker(createDTO);
            }
            catch (FileRequiredException ex)
            {
                var response = new CustomResponse(401,ex.Message);
                return StatusCode(response.Code, response);
            }
            catch(FileExtensionsException ex)
            {
                var response = new CustomResponse(402, ex.Message);
                return StatusCode(response.Code, response);
            }
           
            return Ok();
        }

        [HttpDelete]
        [Route("hardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            if (_service.GetSpeaker(x => x.Id == id && x.IsDeleted == false) is null)
            {
                return NotFound();
            }
            _service.HardDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.GetSpeaker(x => x.Id == id && x.IsDeleted == false) is null)
            {
                return NotFound();
            }
            _service.SoftDelete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, SpeakerUpdateDTO updateDTO)
        {
            if (_service.GetSpeaker(x => x.Id == id && x.IsDeleted == false) is null)
            {
                return NotFound();
            }
            _service.UpdateSpeaker(id, updateDTO);
            return NoContent();
        }

        [HttpPut("Recover/{id}")]
        public IActionResult Recover(int id)
        {
            if (_service.GetSpeaker(x => x.Id == id && x.IsDeleted == true) is null)
            {
                return NotFound();
            }
            _service.Recover(id);
            return NoContent();
        }

    }
}
