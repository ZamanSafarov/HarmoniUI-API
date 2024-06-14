using Harmoni.Business.DTOs.FAQ;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface IFAQContentService
    {
        FAQContentGetDTO GetFAQContent(Func<FAQContent, bool>? func = null);
        IEnumerable<FAQContentGetDTO> GetAllFAQContents(Func<FAQContent, bool>? func = null);
        void AddFAQContent(FAQContentCreateDTO faqContent);
        void UpdateFAQContent(int id,FAQContentUpdateDTO faqContent);
        void Recover(int id);

        void SoftDelete(int id);
        void HardDelete(int id);
    }
}
