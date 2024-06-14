using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.Entities
{
    public class FAQContent:BaseEntity
    {
        public string Name { get; set; }
        public List<FAQ> FAQs { get; set; }
    }
}
