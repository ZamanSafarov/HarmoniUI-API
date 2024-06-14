using Harmoni.Core.Entities;
using Harmoni.Data.DAL;
using Harmoni.Data.RepConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.RepAbstracts
{
    public class FAQRepository : GenericRepository<FAQ>, IFAQRepository
    {
        public FAQRepository(AppDbContext db) : base(db)
        {
        }
    }
}
