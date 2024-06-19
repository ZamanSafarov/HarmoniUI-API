using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.About
{
    public class AdvantageCreateDTO
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Icon { get; set; }
    }
    public class AdvantageCreateDTOValidator : AbstractValidator<AdvantageCreateDTO>
    {

        public AdvantageCreateDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Cannot be Empty");
            RuleFor(x => x.ShortDescription).NotEmpty().NotNull().WithMessage("Cannot be Empty");
            RuleFor(x => x.Icon).NotEmpty().NotNull().WithMessage("Select Award Date!");
        }

    }
}
