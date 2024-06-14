using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Services.Concretes
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public void Add(SettingCreateDTO settingDTO)
        {
            var setting = _mapper.Map<Setting>(settingDTO);
            _settingRepository.Add(setting);
            _settingRepository.Commit();
        }

        public List<SettingGetDTO> GetAllSetting(Func<Setting, bool>? func = null)
        {
            var settings = _settingRepository.GetAll(func);

            List<SettingGetDTO> dtoList = new List<SettingGetDTO>();
            foreach (var setting in settings)
            {
                var settingDto = _mapper.Map<SettingGetDTO>(setting);
                dtoList.Add(settingDto);
            }
            return dtoList;

        }

		public SettingGetDTO GetSetting(Func<Setting, bool>? func = null)
        {
            var setting = _settingRepository.Get(func);

            var settingDto = _mapper.Map<SettingGetDTO>(setting);
            return settingDto;
        }

        public Dictionary<string, string> GetSettingAsync(Func<Setting, bool>? func = null)
        {
             return _settingRepository.GetSettingAsync(func);
        }

        public void HardDelete(int id)
        {
            var setting = _settingRepository.Get(x=>x.Id==id);

            _settingRepository.HardDelete(setting);
            _settingRepository.Commit();
        }

        public void SoftDelete(int id)
        {
            var setting = _settingRepository.Get(x => x.Id == id);

            setting.DeletedDate = DateTime.UtcNow.AddHours(4);

            _settingRepository.SoftDelete(setting);
            _settingRepository.Commit();
        }

        public void Update(int id,SettingUpdateDTO updateDTO)
        {
            var exsistSetting = _settingRepository.Get(x=>x.Id==id && x.IsDeleted==false);

            exsistSetting = _mapper.Map(updateDTO,exsistSetting);

            exsistSetting.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _settingRepository.Commit();
        }
        public void Recover(int id)
        {
            var exsistSetting = _settingRepository.Get(x => x.Id == id && x.IsDeleted == true);

            exsistSetting.DeletedDate = null;
            exsistSetting.IsDeleted = false;
            _settingRepository.Commit();
        }

    }
}
