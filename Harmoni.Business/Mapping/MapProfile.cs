using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<SettingCreateDTO, Setting>().ReverseMap();
            CreateMap<SettingGetDTO, Setting>().ReverseMap();
            CreateMap<SettingUpdateDTO, Setting>().ReverseMap();
        }
    }
}
