using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Business.ManagerServices.Concretes;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.DependecyResolvers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessModule(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutRepository, AboutRepository>();

            services.AddScoped<IGenericRepository<AboutImage>, GenericRepository<AboutImage>>();

            services.AddScoped<IAboutImageService, AboutImageManager>();
            services.AddScoped<IAboutImageRepository, AboutImageRepository>();

            services.AddScoped<IBlogImageService, BlogImageManager>();
            services.AddScoped<IBlogImageRepository, BlogImageRepository>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<IGenericRepository<BlogImage>, GenericRepository<BlogImage>>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IGenericRepository<Teacher>, GenericRepository<Teacher>>();

            services.AddScoped<IGeneralInfoService, GeneralInfoManager>();
            services.AddScoped<IGeneralInfoRepository, GeneralInfoRepository>();

            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddScoped<INewsImageService, NewsImageManager>();
            services.AddScoped<INewsImageRepository, NewsImageRepository>();

            services.AddScoped<IGenericRepository<NewsImage>, GenericRepository<NewsImage>>();

            services.AddScoped<INewsService, NewsManager>();
            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<IOtherInfoDescriptionService, OtherInfoDescriptionManager>();
            services.AddScoped<IOtherInfoDescriptionRepository, OtherInfoDescriptionRepository>();

            services.AddScoped<IGenericRepository<OtherInfo>, GenericRepository<OtherInfo>>();

            services.AddScoped<IOtherInfoService, OtherInfoManager>();
            services.AddScoped<IOtherInfoRepository, OtherInfoRepository>();

            services.AddScoped<ISendMessageService, SendMessageManager>();
            services.AddScoped<ISendMessageRepository, SendMessageRepository>();

            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<ITeacherService, TeacherManager>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();

            services.AddScoped<IVacancyDescriptionService, VacancyDescriptionManager>();
            services.AddScoped<IVacancyDescriptionRepository, VacancyDescriptionRepository>();

            services.AddScoped<IVacancyDetailsService, VacancyDetailsManager>();
            services.AddScoped<IVacancyDetailsRepository, VacancyDetailRepository>();

            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();

            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}