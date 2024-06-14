using FluentValidation;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.FAQ
{
    public class FAQGetDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public FAQContent FAQContent { get; set; }



    }
    public class FAQGetDTOValidator : AbstractValidator<FAQGetDTO>
    {
        public FAQGetDTOValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().NotNull().WithMessage("Answer Boş ola bilməz");
            RuleFor(x => x.Question).NotEmpty().NotNull().WithMessage("Question Boş ola bilməz");
        }
    }
}
