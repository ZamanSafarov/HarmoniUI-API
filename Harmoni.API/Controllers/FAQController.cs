using Harmoni.Business.DTOs.FAQ;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Business.Services.Concretes;
using Harmoni.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FAQGetDTO>> GetFAQs()
        {
            var faqs = _faqService.GetAllFAQs(x=>x.IsDeleted == false);
            return Ok(faqs);
        }

        [HttpGet("{id}")]
        public ActionResult<FAQGetDTO> Get(int id)
        {
            var faq = _faqService.GetFAQ(x => x.Id == id && x.IsDeleted==false);
            if (faq == null)
            {
                return NotFound();
            }
            return Ok(faq);
        }
        [HttpGet("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            return Ok(_faqService.GetAllFAQs(x => x.IsDeleted == true));
        }

        [HttpPost]
        public ActionResult<FAQ> Create(FAQCreateDTO faqDTO)
        {
            _faqService.AddFAQ(faqDTO);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FAQUpdateDTO updateDTO)
        {

            _faqService.UpdateFAQ(id, updateDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("hardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            _faqService.HardDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _faqService.SoftDelete(id);
            return NoContent();
        }
        [HttpPut("Recover/{id}")]
        public IActionResult Recover(int id)
        {
            _faqService.Recover(id);
            return NoContent();
        }
    }
}
