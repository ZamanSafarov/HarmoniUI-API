using Harmoni.Business.DTOs;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface ISpeakerService
    {
        SpeakerGetDTO GetSpeaker(Func<Speaker, bool>? func = null);
        IEnumerable<SpeakerGetDTO> GetAllSpeakers(Func<Speaker, bool>? func = null);
        void AddSpeaker(SpeakerCreateDTO speaker);
        void UpdateSpeaker(int id, SpeakerUpdateDTO speaker);
        void Recover(int id);

        void SoftDelete(int id);
        void HardDelete(int id);
    }
}
