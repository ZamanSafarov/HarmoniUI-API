﻿using Harmoni.Business.DTOs.About;
using Harmoni.Business.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private readonly IAwardService _awardService;

        public AwardsController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AwardGetDTO>> GetAwards()
        {
            var awards = _awardService.GetAllAwards(x => x.IsDeleted == false);
            return Ok(awards);
        }

        [HttpGet("{id}")]
        public ActionResult<AwardGetDTO> Get(int id)
        {
            var award = _awardService.GetAward(x => x.Id == id && x.IsDeleted == false);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }
        [HttpGet("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            return Ok(_awardService.GetAllAwards(x => x.IsDeleted == true));
        }

        [HttpPost]
        public IActionResult Create(AwardCreateDTO awardDTO)
        {
            _awardService.AddAward(awardDTO);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AwardUpdateDTO updateDTO)
        {

            _awardService.UpdateAward(id, updateDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("hardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            _awardService.HardDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _awardService.SoftDelete(id);
            return NoContent();
        }
        [HttpPut("Recover/{id}")]
        public IActionResult Recover(int id)
        {
            _awardService.Recover(id);
            return NoContent();
        }
    }
}