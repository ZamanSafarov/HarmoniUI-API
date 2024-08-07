﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs.About
{
    public class AwardUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }


    }
    public class AwardUpdateDTOValidator : AbstractValidator<AwardUpdateDTO>
    {

        public AwardUpdateDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Cannot be Empty");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Cannot be Empty");
            RuleFor(x => x.Date).NotEmpty().NotNull().WithMessage("Select Award Date!");
        }

    }
}
