
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.UI.DTOs.FAQ
{
    public class FAQGetDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public FAQContent FAQContent { get; set; }


    }
  
}
