using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Business.DTOs.FAQ;
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
            CreateMap<EntityRecoverDTO, Setting>().ReverseMap();
            CreateMap<FAQCreateDTO, FAQ>().ReverseMap();
            CreateMap<FAQGetDTO, FAQ>().ReverseMap();
            CreateMap<FAQUpdateDTO, FAQ>().ReverseMap();
            CreateMap<EntityRecoverDTO, FAQ>().ReverseMap();
            CreateMap<FAQContentCreateDTO, FAQContent>().ReverseMap();
            CreateMap<FAQContentGetDTO, FAQContent>().ReverseMap();
            CreateMap<FAQContentUpdateDTO, FAQContent>().ReverseMap();
            CreateMap<EntityRecoverDTO, FAQContent>().ReverseMap();
            CreateMap<SpeakerCreateDTO, Speaker>().ReverseMap();
            CreateMap<SpeakerUpdateDTO, Speaker>().ReverseMap();
            CreateMap<SpeakerGetDTO, Speaker>().ReverseMap();
            CreateMap<EntityRecoverDTO, Speaker>().ReverseMap();

		}
    }
}
