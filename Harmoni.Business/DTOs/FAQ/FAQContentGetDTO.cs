using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.FAQ
{
    public class FAQContentGetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Harmoni.Core.Entities.FAQ> FAQs { get; set; }
        public int EventId { get; set; }

    }
    public class FAQContentGetDTOValidator : AbstractValidator<FAQContentGetDTO>
    {
        public FAQContentGetDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name Boş ola bilməz");

        }
    }
}
