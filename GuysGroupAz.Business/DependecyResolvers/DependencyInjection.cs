using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.Business.ManagerServices.Concretes;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
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
            services.AddSingleton<IAboutService, AboutManager>();
            services.AddSingleton<IAboutRepository, AboutRepository>();

            services.AddSingleton<IBlogImageService, BlogImageManager>();
            services.AddSingleton<IBlogImageRepository, BlogImageRepository>();

            services.AddSingleton<IBlogImageService, BlogManager>();
            services.AddSingleton<IBlogRepository, BlogRepository>();

            services.AddSingleton<IContactService, ContactManager>();
            services.AddSingleton<IContactRepository, ContactRepository>();

            services.AddSingleton<ICourseService, CourseManager>();
            services.AddSingleton<ICourseRepository, CourseRepository>();

            services.AddSingleton<IGeneralInfoService, GeneralInfoManager>();
            services.AddSingleton<IGeneralInfoRepository, GeneralInfoRepository>();

            services.AddSingleton<IQuestionService, QuestionManager>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();

            services.AddSingleton<INewsService, NewsManager>();
            services.AddSingleton<INewsRepository, NewsRepository>();

            services.AddSingleton<IOtherInfoDescriptionService, OtherInfoDescriptionManager>();
            services.AddSingleton<IOtherInfoDescriptionRepository, OtherInfoDescriptionRepository>();

            services.AddSingleton<IOtherInfoService, OtherInfoManager>();
            services.AddSingleton<IOtherInfoRepository, OtherInfoRepository>();

            services.AddSingleton<ISendMessageService, SendMessageManager>();
            services.AddSingleton<ISendMessageRepository, SendMessageRepository>();

            services.AddSingleton<ISubscribeService, SubscribeManager>();
            services.AddSingleton<ISubscribeRepository, SubscribeRepository>();

            services.AddSingleton<ITeacherService, TeacherManager>();
            services.AddSingleton<ITeacherRepository, TeacherRepository>();

            services.AddSingleton<IVacancyDescriptionService, VacancyDescriptionManager>();
            services.AddSingleton<IVacancyDescriptionRepository, VacancyDescriptionRepository>();

            services.AddSingleton<IVacancyDetailsService, VacancyDetailsManager>();
            services.AddSingleton<IVacancyDetailsRepository, VacancyDetailRepository>();

            services.AddSingleton<IVacancyService, VacancyManager>();
            services.AddSingleton<IVacancyRepository, VacancyRepository>();

            return services;
        }
    }
}