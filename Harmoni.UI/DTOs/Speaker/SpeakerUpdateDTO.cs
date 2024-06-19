
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.UI.DTOs.Speaker
{
    public class SpeakerUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public IFormFile? FormFile { get; set; }

        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? XUrl { get; set; }
        public string? TwitchUrl { get; set; }
    }

}
