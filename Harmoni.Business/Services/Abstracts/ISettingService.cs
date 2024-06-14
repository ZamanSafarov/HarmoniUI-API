using Harmoni.Business.DTOs;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Abstracts
{
    public interface ISettingService
    {
        void SoftDelete(int id);
        void HardDelete(int id);
        void Add(SettingCreateDTO settingDTO);
        void Update(int id,SettingUpdateDTO updateDTO);
        void Recover(int id);
        SettingGetDTO GetSetting(Func<Setting, bool>? func = null);
        List<SettingGetDTO> GetAllSetting(Func<Setting, bool>? func = null);

        Dictionary<string, string> GetSettingAsync(Func<Setting, bool>? func = null);


	}
}
