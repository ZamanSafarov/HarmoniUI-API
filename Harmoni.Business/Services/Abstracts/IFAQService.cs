using Harmoni.Business.DTOs.FAQ;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface IFAQService
    {
        FAQGetDTO GetFAQ(Func<FAQ, bool>? func = null);
        IEnumerable<FAQGetDTO> GetAllFAQs(Func<FAQ, bool>? func = null);
        void AddFAQ(FAQCreateDTO faq);
        void UpdateFAQ(int id,FAQUpdateDTO faq);
        void Recover(int id);

        void SoftDelete(int id);
        void HardDelete(int id);
    }
}
