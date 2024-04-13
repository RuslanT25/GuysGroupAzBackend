using AutoMapper;
using GuysGroupAz.Entity.DTOs.Contact;
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
        }
    }
}
