
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.UI.DTOs.FAQ
{
    public class FAQContentGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FAQ> FAQs { get; set; }
    }
  
}
