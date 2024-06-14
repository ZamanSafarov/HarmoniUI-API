using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Business.DTOs.FAQ;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Concretes
{
    public class FAQContentService : IFAQContentService
    {
        private readonly IFAQContentRepository _repository;
        private readonly IMapper _mapper;

        public FAQContentService(IFAQContentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddFAQContent(FAQContentCreateDTO faqContentDTO)
        {
            var faqContent = _mapper.Map<FAQContent>(faqContentDTO);
            _repository.Add(faqContent);
            _repository.Commit();
        }

        public IEnumerable<FAQContentGetDTO> GetAllFAQContents(Func<FAQContent, bool>? func = null)
        {
            var faqContentContents = _repository.GetAll(func, "FAQs");

            List<FAQContentGetDTO> dtoList = new List<FAQContentGetDTO>();
            foreach (var faqContent in faqContentContents)
            {
                var faqContentDto = _mapper.Map<FAQContentGetDTO>(faqContent);
                dtoList.Add(faqContentDto);
            }
            return dtoList;

        }

		public FAQContentGetDTO GetFAQContent(Func<FAQContent, bool>? func = null)
        {
            var faqContent = _repository.Get(func, "FAQs");

            var faqContentDto = _mapper.Map<FAQContentGetDTO>(faqContent);
            return faqContentDto;
        }


        public void HardDelete(int id)
        {
            var faqContent = _repository.Get(x=>x.Id==id);

            _repository.HardDelete(faqContent);
            _repository.Commit();
        }

        public void SoftDelete(int id)
        {
            var faqContent = _repository.Get(x => x.Id == id);

            faqContent.DeletedDate = DateTime.UtcNow.AddHours(4);

            _repository.SoftDelete(faqContent);
            _repository.Commit();
        }

        public void UpdateFAQContent(int id,FAQContentUpdateDTO updateDTO)
        {
            var exsistFAQContent = _repository.Get(x=>x.Id==id && x.IsDeleted==false);

            exsistFAQContent = _mapper.Map(updateDTO,exsistFAQContent);

            exsistFAQContent.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _repository.Commit();
        }
        public void Recover(int id)
        {
            var exsistFAQContent = _repository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistFAQContent.IsDeleted = false;
            _repository.Commit();
        }

    }
}
