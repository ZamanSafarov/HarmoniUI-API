using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.Entities
{
    public class FAQ:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int FAQContentId { get; set; }
        public FAQContent FAQContent { get; set; }
    }
}
