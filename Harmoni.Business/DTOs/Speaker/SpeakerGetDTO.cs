using FluentValidation;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs
{
    public class SpeakerGetDTO
    {
        public int Id { get; set; }
		
        public string Name { get; set; }
		public string Description { get; set; }
		public int Experience { get; set; }
		public string ImageUrl { get; set; }
		public string FacebookUrl { get; set; }
		public string InstagramUrl { get; set; }
		public string XUrl { get; set; }
		public string TwitchUrl { get; set; }

	}
 
}
