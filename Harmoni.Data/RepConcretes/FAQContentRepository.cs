using Harmoni.Core.Entities;
using Harmoni.Data.DAL;
using Harmoni.Data.RepConcretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.RepAbstracts
{
    public class FAQContentRepository:GenericRepository<FAQContent>, IFAQContentRepository
    {
        public FAQContentRepository(AppDbContext db):base(db)
        {
                
        }
    }
}
