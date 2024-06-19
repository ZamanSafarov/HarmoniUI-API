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
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _repository;
        private readonly IMapper _mapper;

        public AwardService(IAwardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddAward(AwardCreateDTO awardDto)
        {
            var award = _mapper.Map<Award>(awardDto);
            _repository.Add(award);
            _repository.Commit();
        }

        public IEnumerable<AwardGetDTO> GetAllAwards(Func<Award, bool>? func = null)
        {
            var awards = _repository.GetAll(func);

            List<AwardGetDTO> dtoList = new List<AwardGetDTO>();
            foreach (var award in awards)
            {
                var awardDto = _mapper.Map<AwardGetDTO>(award);
                dtoList.Add(awardDto);
            }
            return dtoList;
        }

        public AwardGetDTO GetAward(Func<Award, bool>? func = null)
        {
            var award = _repository.Get(func);

            var awardsDto = _mapper.Map<AwardGetDTO>(award);
            return awardsDto;
        }

        public void HardDelete(int id)
        {
            var award = _repository.Get(x => x.Id == id);

            _repository.HardDelete(award);
            _repository.Commit();
        }

        public void Recover(int id)
        {
            var exsistAward = _repository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistAward.DeletedDate = null;
            exsistAward.IsDeleted = false;
            _repository.Commit();
        }

        public void SoftDelete(int id)
        {
            var award = _repository.Get(x => x.Id == id);

            award.DeletedDate = DateTime.UtcNow.AddHours(4);

            _repository.SoftDelete(award);
            _repository.Commit();
        }

        public void UpdateAward(int id, AwardUpdateDTO awardDto)
        {
            var exsistAward = _repository.Get(x => x.Id == id && x.IsDeleted == false);

            exsistAward = _mapper.Map(awardDto, exsistAward);

            exsistAward.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _repository.Commit();
        }
    }
}
