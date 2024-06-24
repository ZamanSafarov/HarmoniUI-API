using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.Entities
{
	public class Speaker:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Experience { get; set; }
		public string? ImageUrl { get; set; }
		public string? FacebookUrl { get; set; }
		public string? InstagramUrl { get; set; }
		public string? XUrl { get; set; }
		public string? TwitchUrl { get; set; }

        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
