using Harmoni.Business.DTOs.About;
using Harmoni.Business.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvantagesController : ControllerBase
    {
        private readonly IAdvantageService _service;

        public AdvantagesController(IAdvantageService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdvantageGetDTO>> GetAdvantages()
        {
            var advantages = _service.GetAllAdvantages(x => x.IsDeleted == false);
            return Ok(advantages);
        }

        [HttpGet("{id}")]
        public ActionResult<AdvantageGetDTO> Get(int id)
        {
            var advantage = _service.GetAdvantage(x => x.Id == id && x.IsDeleted == false);
            if (advantage == null)
            {
                return NotFound();
            }
            return Ok(advantage);
        }
        [HttpGet("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            return Ok(_service.GetAllAdvantages(x => x.IsDeleted == true));
        }

        [HttpPost]
        public IActionResult Create(AdvantageCreateDTO advantageDTO)
        {
            _service.AddAdvantage(advantageDTO);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AdvantageUpdateDTO updateDTO)
        {

            _service.UpdateAdvantage(id, updateDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("hardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            _service.HardDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.SoftDelete(id);
            return NoContent();
        }
        [HttpPut("Recover/{id}")]
        public IActionResult Recover(int id)
        {
            _service.Recover(id);
            return NoContent();
        }
    }
}
