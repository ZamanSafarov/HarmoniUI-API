using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs
{
    public class SpeakerCreateDTO
	{
        public string Name { get; set; }
		public string Description { get; set; }
		public int Experience { get; set; }
		public IFormFile FormFile { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? XUrl { get; set; }
        public string? TwitchUrl { get; set; }
    }
	public class SpeakerCreateDTOValidator : AbstractValidator<SpeakerCreateDTO>
	{
		public SpeakerCreateDTOValidator()
		{

			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Boş ola bilməz")
				.MaximumLength(256).WithMessage("256 dan çox ola bilməz!");

			RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Boş ola bilməz")
				.MaximumLength(256).WithMessage("256 dan çox ola bilməz!");
			RuleFor(x => x.Experience).NotNull().NotEmpty().WithMessage("Boş ola bilməz").Must(x=>x>2);


		}
	}
}
