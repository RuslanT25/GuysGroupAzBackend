using AutoMapper;
using GuysGroupAz.Entity.DTOs.About;
using GuysGroupAz.Entity.DTOs.AboutImage;
using GuysGroupAz.Entity.DTOs.Blog;
using GuysGroupAz.Entity.DTOs.BlogImage;
using GuysGroupAz.Entity.DTOs.Contact;
using GuysGroupAz.Entity.DTOs.Course;
using GuysGroupAz.Entity.DTOs.GeneralInfo;
using GuysGroupAz.Entity.DTOs.News;
using GuysGroupAz.Entity.DTOs.NewsImage;
using GuysGroupAz.Entity.DTOs.OtherInfo;
using GuysGroupAz.Entity.DTOs.OtherInfoDescription;
using GuysGroupAz.Entity.DTOs.Question;
using GuysGroupAz.Entity.DTOs.SendMessage;
using GuysGroupAz.Entity.DTOs.Service;
using GuysGroupAz.Entity.DTOs.Subcribe;
using GuysGroupAz.Entity.DTOs.Teacher;
using GuysGroupAz.Entity.DTOs.Vacancy;
using GuysGroupAz.Entity.DTOs.VacancyDescription;
using GuysGroupAz.Entity.DTOs.VacancyDetail;
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

            CreateMap<Teacher, TeacherPostDTO>().ReverseMap();
            CreateMap<Teacher, TeacherGetDTO>()
                .ForMember(dto => dto.Course, opt => opt.MapFrom(x => x.Course.Name))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/teachers/" + x.Image)).ReverseMap();

            CreateMap<CoursePostDTO, Course>()
                .ForMember(b => b.Teachers, opt => opt.Ignore())
                .ForMember(c => c.Questions, opt => opt.Ignore());
            CreateMap<Course, CourseGetDTO>()
                .ForMember(dto => dto.Type, opt => opt.MapFrom(x => x.Type.ToString()))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/courses/" + x.Image)).ReverseMap();

            CreateMap<AboutImagePostDTO, AboutImage>().ReverseMap();
            CreateMap<AboutImage, AboutImageGetDTO>()
                .ForMember(dto => dto.Image, opt => opt.MapFrom(x => "https://localhost:7142/uploads/photos/aboutimages/" + x.Image)).ReverseMap();

            CreateMap<AboutPostDTO, About>()
           .ForMember(b => b.AboutImages, opt => opt.Ignore());
            CreateMap<About, AboutGetDTO>().ReverseMap();

            CreateMap<OtherInfoDescription, OtherInfoDescriptionPostDTO>().ReverseMap();
            CreateMap<OtherInfoDescription, OtherInfoDescriptionGetDTO>()
                .ForMember(dto => dto.OtherInfo, opt => opt.MapFrom(x => x.OtherInfo.Title));

            CreateMap<OtherInfoPostDTO, OtherInfo>()
                .ForMember(b => b.OtherInfoDescriptions, opt => opt.Ignore());
            CreateMap<OtherInfo, OtherInfoGetDTO>().ReverseMap();

            CreateMap<VacancyDescription, VacancyDescriptionGetDTO>().ReverseMap();
            CreateMap<VacancyDescription, VacancyDescriptionPostDTO>().ReverseMap();

            CreateMap<VacancyDetailPostDTO, VacancyDetail>()
                .ForMember(b => b.VacancyDescriptions, opt => opt.Ignore());
            CreateMap<VacancyDetail, VacancyDetailGetDTO>().ReverseMap();

            CreateMap<VacancyPostDTO, Vacancy>()
                .ForMember(b => b.VacancyDetails, opt => opt.Ignore());
            CreateMap<Vacancy, VacancyGetDTO>().ReverseMap();

            CreateMap<QuestionPostDTO, Question>().ReverseMap();
            CreateMap<Question, QuestionGetDTO>().ReverseMap();
        }
    }
}