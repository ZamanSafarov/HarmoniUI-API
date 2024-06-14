using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.FAQ
{
    public class FAQContentCreateDTO
    {
        public string Name { get; set; }
    }
    public class FAQContentCreateDTOValidator : AbstractValidator<FAQContentCreateDTO>
    {
        public FAQContentCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name Boş ola bilməz");
        }
    }
}
