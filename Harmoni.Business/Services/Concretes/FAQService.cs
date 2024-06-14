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
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _repository;
        private readonly IMapper _mapper;

        public FAQService(IFAQRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddFAQ(FAQCreateDTO faqDTO)
        {
            var faq = _mapper.Map<FAQ>(faqDTO);
            _repository.Add(faq);
            _repository.Commit();
        }

        public IEnumerable<FAQGetDTO> GetAllFAQs(Func<FAQ, bool>? func = null)
        {
            var faqs = _repository.GetAll(func, "FAQContent");

            List<FAQGetDTO> dtoList = new List<FAQGetDTO>();
            foreach (var faq in faqs)
            {
                var faqDto = _mapper.Map<FAQGetDTO>(faq);
                dtoList.Add(faqDto);
            }
            return dtoList;

        }

		public FAQGetDTO GetFAQ(Func<FAQ, bool>? func = null)
        {
            var faq = _repository.Get(func, "FAQContent");

            var faqDto = _mapper.Map<FAQGetDTO>(faq);
            return faqDto;
        }


        public void HardDelete(int id)
        {
            var faq = _repository.Get(x=>x.Id==id);

            _repository.HardDelete(faq);
            _repository.Commit();
        }

        public void SoftDelete(int id)
        {
            var faq = _repository.Get(x => x.Id == id);

            faq.DeletedDate = DateTime.UtcNow.AddHours(4);

            _repository.SoftDelete(faq);
            _repository.Commit();
        }

        public void UpdateFAQ(int id,FAQUpdateDTO updateDTO)
        {
            var exsistFAQ = _repository.Get(x=>x.Id==id && x.IsDeleted==false, "FAQContent");

            exsistFAQ = _mapper.Map(updateDTO,exsistFAQ);

            exsistFAQ.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _repository.Commit();
        }
        public void Recover(int id)
        {
            var exsistFAQ = _repository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistFAQ.IsDeleted = false;
            _repository.Commit();
        }

    }
}
