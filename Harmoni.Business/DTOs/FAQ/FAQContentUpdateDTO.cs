using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.FAQ
{
    public class FAQContentUpdateDTO
    {
        public string Name { get; set; }



    }
    public class FAQContentUpdateDTOValidator : AbstractValidator<FAQContentUpdateDTO>
    {
        public FAQContentUpdateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name Boş ola bilməz");
        }
    }
}
