using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Business.Exceptions;
using Harmoni.Business.Helper;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Concretes
{
    public class SpeakerService:ISpeakerService
    {
        private readonly ISpeakerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SpeakerService(ISpeakerRepository repository, IMapper mapper, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }

        public void AddSpeaker([FromForm]SpeakerCreateDTO speakerDto)
        {
            if (speakerDto.FormFile is null)
            {
                throw new FileRequiredException("File Cannot be null!");
            }
          
            var speaker = _mapper.Map<Speaker>(speakerDto);
            speaker.ImageUrl = _env.FileAdd("uploads\\speakers", speakerDto.FormFile, "speaker");

            _repository.Add(speaker);
            _repository.Commit();
        }

        public IEnumerable<SpeakerGetDTO> GetAllSpeakers(Func<Speaker, bool>? func = null)
        {
            var speakers = _repository.GetAll(func);

            List<SpeakerGetDTO> dtoList = new List<SpeakerGetDTO>();
            foreach (var speaker in speakers)
            {
                var speakerDto = _mapper.Map<SpeakerGetDTO>(speaker);
                dtoList.Add(speakerDto);
            }
            return dtoList;
        }

        public SpeakerGetDTO GetSpeaker(Func<Speaker, bool>? func = null)
        {
            var speaker = _repository.Get(func);

            var speakerDto = _mapper.Map<SpeakerGetDTO>(speaker);
            return speakerDto;
        }

        public void HardDelete(int id)
        {
            var speaker = _repository.Get(x => x.Id == id);

            _repository.HardDelete(speaker);
            _env.ArchiveFile("uploads\\speakers", speaker.ImageUrl);
            _repository.Commit();
        }

        public void SoftDelete(int id)
        {
            var speaker = _repository.Get(x => x.Id == id);

            speaker.DeletedDate = DateTime.UtcNow.AddHours(4);

            _repository.SoftDelete(speaker);
            _repository.Commit();
        }
        public void Recover(int id)
        {
            var exsistSpeaker= _repository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistSpeaker.IsDeleted = false;
            _repository.Commit();
        }

      

        public void UpdateSpeaker(int id, SpeakerUpdateDTO speakerDto)
        {
            var oldSpeaker = _repository.Get(x => x.Id == id && x.IsDeleted == false);
            if (oldSpeaker is null)
            {
                throw new EntityNotFoundException("Speaker is not exist!");
            }
            _mapper.Map(speakerDto, oldSpeaker);
            if (speakerDto.FormFile != null)
            {
                _env.ArchiveFile("uploads\\speakers", oldSpeaker.ImageUrl);
                oldSpeaker.ImageUrl = _env.FileAdd("uploads\\speakers", speakerDto.FormFile, "speaker");

            }
            oldSpeaker.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _repository.Commit();
        }
    }
}
