using AutoMapper;
using GuysGroupAz.Entity.DTOs.Blog;
using GuysGroupAz.Entity.DTOs.BlogImage;
using GuysGroupAz.Entity.DTOs.Contact;
using GuysGroupAz.Entity.DTOs.GeneralInfo;
using GuysGroupAz.Entity.DTOs.News;
using GuysGroupAz.Entity.DTOs.NewsImage;
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

            CreateMap<BlogImagePostDTO, BlogImage>().ReverseMap();
            CreateMap<BlogImage, BlogImageGetDTO>()
                .ForMember(dto => dto.Image, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/blogimages/" + x.Image)).ReverseMap();

            CreateMap<BlogPostDTO, Blog>()
            .ForMember(b => b.BlogImages, opt => opt.Ignore());
            CreateMap<Blog, BlogGetDTO>()
                .ForMember(dto => dto.CoverImage, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/blogs/" + x.CoverImage)).ReverseMap();

            CreateMap<NewsImagePostDTO, NewsImage>().ReverseMap();
            CreateMap<NewsImage, NewsImageGetDTO>()
                .ForMember(dto => dto.Image, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/newsimages/" + x.Image)).ReverseMap();

            CreateMap<NewsPostDTO, News>()
           .ForMember(b => b.NewsImages, opt => opt.Ignore());
            CreateMap<News, NewsGetDTO>()
                .ForMember(dto => dto.CoverImage, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/news/" + x.CoverImage)).ReverseMap();
        }
    }
}