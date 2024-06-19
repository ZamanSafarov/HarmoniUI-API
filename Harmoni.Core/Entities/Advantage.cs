using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.Entities
{
    public class Advantage:BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Icon { get; set; }
    }
}
