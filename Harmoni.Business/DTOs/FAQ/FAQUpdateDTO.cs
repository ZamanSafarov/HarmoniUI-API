using FluentValidation;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.FAQ
{
    public class FAQUpdateDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public int FAQContentId { get; set; }
    }
    public class FAQUpdateDTOValidator : AbstractValidator<FAQUpdateDTO>
    {
        public FAQUpdateDTOValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().NotNull().WithMessage("Answer Boş ola bilməz");
            RuleFor(x => x.Question).NotEmpty().NotNull().WithMessage("Question Boş ola bilməz");
        }
    }
}
