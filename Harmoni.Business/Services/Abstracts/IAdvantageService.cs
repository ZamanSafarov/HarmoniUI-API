using Harmoni.Business.DTOs.About;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface IAdvantageService
    {
        AdvantageGetDTO GetAdvantage(Func<Advantage, bool>? func = null);
        IEnumerable<AdvantageGetDTO> GetAllAdvantages(Func<Advantage, bool>? func = null);
        void AddAdvantage(AdvantageCreateDTO advantage);
        void UpdateAdvantage(int id, AdvantageUpdateDTO advantage);
        void Recover(int id);

        void SoftDelete(int id);
        void HardDelete(int id);
    }
}
