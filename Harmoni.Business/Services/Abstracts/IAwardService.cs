using Harmoni.Business.DTOs.About;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface IAwardService
    {
        AwardGetDTO GetAward(Func<Award, bool>? func = null);
        IEnumerable<AwardGetDTO> GetAllAwards(Func<Award, bool>? func = null);
        void AddAward(AwardCreateDTO award);
        void UpdateAward(int id, AwardUpdateDTO award);
        void Recover(int id);

        void SoftDelete(int id);
        void HardDelete(int id);
    }
}
