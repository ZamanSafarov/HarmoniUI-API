using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.DTOs
{
    public class EntityRecoverDTO
    {
         public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
