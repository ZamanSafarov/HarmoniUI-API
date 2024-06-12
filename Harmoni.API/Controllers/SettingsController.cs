﻿using Harmoni.Business.DTOs;
using Harmoni.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Harmoni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _service;

        public SettingsController(ISettingService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetSetting(x => x.Id == id && x.IsDeleted == false));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllSetting(x => x.IsDeleted == false));
        }
       
        [HttpPost]
        public IActionResult Create(SettingCreateDTO createDTO)
        {
            _service.Add(createDTO);
            return Ok();
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, SettingUpdateDTO updateDTO)
        {
			_service.Update(id,updateDTO);
			return NoContent();
		}

    }
}
