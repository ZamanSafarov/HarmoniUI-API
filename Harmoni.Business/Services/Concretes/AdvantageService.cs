using AutoMapper;
using Harmoni.Business.DTOs.About;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.RepConcretes;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Concretes
{
    public class AdvantageService : IAdvantageService
    {
        private readonly IAdvantageRepository _repository;
        private readonly IMapper _mapper;

        public AdvantageService(IAdvantageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddAdvantage(AdvantageCreateDTO advantageDto)
        {
            var advantage = _mapper.Map<Advantage>(advantageDto);
            _repository.Add(advantage);
            _repository.Commit();
        }

        public IEnumerable<AdvantageGetDTO> GetAllAdvantages(Func<Advantage, bool>? func = null)
        {
            var advantages = _repository.GetAll(func);

            List<AdvantageGetDTO> dtoList = new List<AdvantageGetDTO>();
            foreach (var advantage in advantages)
            {
                var advantageDto = _mapper.Map<AdvantageGetDTO>(advantage);
                dtoList.Add(advantageDto);
            }
            return dtoList;
        }

        public AdvantageGetDTO GetAdvantage(Func<Advantage, bool>? func = null)
        {
            var advantage = _repository.Get(func);

            var advantagesDto = _mapper.Map<AdvantageGetDTO>(advantage);
            return advantagesDto;
        }

        public void HardDelete(int id)
        {
            var advantage = _repository.Get(x => x.Id == id);

            _repository.HardDelete(advantage);
            _repository.Commit();
        }

        public void Recover(int id)
        {
            var exsistAdvantage = _repository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistAdvantage.DeletedDate = null;
            exsistAdvantage.IsDeleted = false;
            _repository.Commit();
        }

        public void SoftDelete(int id)
        {
            var advantage = _repository.Get(x => x.Id == id);

            advantage.DeletedDate = DateTime.UtcNow.AddHours(4);

            _repository.SoftDelete(advantage);
            _repository.Commit();
        }

        public void UpdateAdvantage(int id, AdvantageUpdateDTO advantageDto)
        {
            var exsistAdvantage = _repository.Get(x => x.Id == id && x.IsDeleted == false);

            exsistAdvantage = _mapper.Map(advantageDto, exsistAdvantage);

            exsistAdvantage.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _repository.Commit();
        }
    }
}
