using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Data.RepConcretes
{
    public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(AppDbContext db) : base(db)
        {
        }
    }
}
