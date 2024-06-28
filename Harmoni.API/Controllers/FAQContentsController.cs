using Harmoni.Business.Common;
using Harmoni.Business.DTOs.FAQ;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class FAQContentsController : ControllerBase
    {
        private readonly IFAQContentService _faqContentService;

        public FAQContentsController(IFAQContentService faqContentService)
        {
            _faqContentService = faqContentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FAQContentGetDTO>> GetFAQContents()
        {
            var faqContents = _faqContentService.GetAllFAQContents(x=> x.IsDeleted == false);
            return Ok(faqContents);
        }

        [HttpGet("{id}")]
        public ActionResult<FAQContentGetDTO> Get(int id)
        {
            var faqContent = _faqContentService.GetFAQContent(x => x.Id == id && x.IsDeleted==false);
            if (faqContent == null)
            {
                return NotFound();
            }
            return Ok(faqContent);
        }
        [HttpGet("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            return Ok(_faqContentService.GetAllFAQContents(x => x.IsDeleted == true));
        }
        [HttpPost]
        public ActionResult<FAQContent> Create(FAQContentCreateDTO faqContentDTO)
        {
			if (_faqContentService.GetAllFAQContents().Any(x => x.Name == faqContentDTO.Name))
			{
                var response = new CustomResponse(400, "Name Already exsist!");

				return StatusCode(response.Code,response);
			}
			_faqContentService.AddFAQContent(faqContentDTO);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FAQContentUpdateDTO updateDTO)
        {
           
            _faqContentService.UpdateFAQContent(id, updateDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("hardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            _faqContentService.HardDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _faqContentService.SoftDelete(id);
            return NoContent();
        }
        [HttpPut("Recover/{id}")]
        public IActionResult Recover(int id)
        {
            _faqContentService.Recover(id);
            return NoContent();
        }
    }
}
