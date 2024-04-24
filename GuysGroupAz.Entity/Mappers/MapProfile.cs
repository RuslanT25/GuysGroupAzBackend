using AutoMapper;
using GuysGroupAz.Entity.DTOs.Contact;
using GuysGroupAz.Entity.DTOs.GeneralInfo;
using GuysGroupAz.Entity.DTOs.SendMessage;
using GuysGroupAz.Entity.DTOs.Service;
using GuysGroupAz.Entity.DTOs.Subcribe;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Contact, ContactPostDTO>().ReverseMap();
            CreateMap<Contact, ContactGetDTO>().ReverseMap();

            CreateMap<Service, ServicePostDTO>().ReverseMap();
            CreateMap<Service, ServiceGetDTO>().ReverseMap();

            CreateMap<SendMessage, SendMessagePostDTO>().ReverseMap();
            CreateMap<SendMessage, SendMessageGetDTO>().ReverseMap();

            CreateMap<Subscribe, SubscribePostDTO>().ReverseMap();
            CreateMap<Subscribe, SubscribeGetDTO>().ReverseMap();

            CreateMap<GeneralInfo, GeneralInfoPostDTO>().ReverseMap();
            CreateMap<GeneralInfo, GeneralInfoGetDTO>().ReverseMap();
        }
    }
}
