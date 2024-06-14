using FluentValidation;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs
{
    public class SettingGetDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
    public class SettingGetDTOValidator : AbstractValidator<SettingGetDTO>
    {
        public SettingGetDTOValidator() { 
        
            RuleFor(x=>x.Key).NotNull().NotEmpty().WithMessage("Key Boş ola bilməz")
                .MaximumLength(256).WithMessage("256 dan çox ola bilməz!");

			RuleFor(x => x.Value).NotNull().NotEmpty().WithMessage("Value Boş ola bilməz")
				.MaximumLength(256).WithMessage("256 dan çox ola bilməz!");


		}
    }
}
