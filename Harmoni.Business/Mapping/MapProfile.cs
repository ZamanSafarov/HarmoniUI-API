using AutoMapper;
using Harmoni.Business.DTOs;
using Harmoni.Business.DTOs.About;
using Harmoni.Business.DTOs.Event;
using Harmoni.Business.DTOs.FAQ;
using Harmoni.Business.DTOs.Gallery;
using Harmoni.Business.DTOs.Schedule;
using Harmoni.Business.DTOs.Tickets;
using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Harmoni.Core.Entities.EventSchedule;

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

            CreateMap<AwardCreateDTO, Award>().ReverseMap();
            CreateMap<AwardUpdateDTO, Award>().ReverseMap();
            CreateMap<AwardGetDTO, Award>().ReverseMap();
            CreateMap<EntityRecoverDTO, Award>().ReverseMap();

            CreateMap<AdvantageCreateDTO, Advantage>().ReverseMap();
            CreateMap<AdvantageUpdateDTO, Advantage>().ReverseMap();
            CreateMap<AdvantageGetDTO, Advantage>().ReverseMap();
            CreateMap<EntityRecoverDTO, Advantage>().ReverseMap();

			CreateMap<GalleryCreateDTO, Gallery>().ReverseMap();
			CreateMap<GalleryUpdateDTO, Gallery>().ReverseMap();
			CreateMap<GalleryGetDTO, Gallery>().ReverseMap();
			CreateMap<EntityRecoverDTO, Gallery>().ReverseMap();

            CreateMap<EventCreateDTO, Event>().ReverseMap();
            CreateMap<EventGetDTO, Event>().ReverseMap();
            CreateMap<EventUpdateDTO, Event>().ReverseMap();
            CreateMap<EntityRecoverDTO, Event>().ReverseMap();

            CreateMap<Day, CreateDayDTO>().ReverseMap();
            CreateMap<Day, UpdateDayDTO>().ReverseMap();
            CreateMap<Day, DayDTO>().ReverseMap();

            CreateMap<Location, CreateLocationDTO>().ReverseMap();
            CreateMap<Location, UpdateLocationDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();

            CreateMap<EventSchedule, CreateEventScheduleDTO>().ReverseMap();
            CreateMap<EventSchedule, UpdateEventScheduleDTO>().ReverseMap();
            CreateMap<EventSchedule, EventScheduleDTO>().ReverseMap();

            CreateMap<TicketGetDTO,Ticket>().ReverseMap();
            CreateMap<TicketCreateDTO, Ticket>().ReverseMap();
            CreateMap<TicketUpdateDTO, Ticket>().ReverseMap();
            CreateMap<EntityRecoverDTO, Ticket>().ReverseMap();


        }
    }
}
