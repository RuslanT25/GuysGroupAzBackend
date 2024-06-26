﻿using GuysGroupAz.Entity.Validations;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.DependecyResolvers
{
    public static class ValidationRegistry
    {
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ContactValidation>();
            services.AddValidatorsFromAssemblyContaining<ServiceValidation>();
            services.AddValidatorsFromAssemblyContaining<SendMessageValidation>();
            services.AddValidatorsFromAssemblyContaining<SubscribeValidation>();
            services.AddValidatorsFromAssemblyContaining<GeneralInfoValidation>();
            services.AddValidatorsFromAssemblyContaining<BlogImageValidation>();
            services.AddValidatorsFromAssemblyContaining<BlogValidation>();
            services.AddValidatorsFromAssemblyContaining<NewsImageValidation>();
            services.AddValidatorsFromAssemblyContaining<TeacherValidation>();
            services.AddValidatorsFromAssemblyContaining<CourseValidation>();
            services.AddValidatorsFromAssemblyContaining<AboutImageValidation>();
            services.AddValidatorsFromAssemblyContaining<AboutValidation>();
            services.AddValidatorsFromAssemblyContaining<OtherInfoValidation>();
            services.AddValidatorsFromAssemblyContaining<OtherInfoDescriptionValidation>();
            services.AddValidatorsFromAssemblyContaining<VacancyDescriptionValidation>();
            services.AddValidatorsFromAssemblyContaining<VacancyDetailValidation>();
            services.AddValidatorsFromAssemblyContaining<VacancyValidation>();

            return services;
        }
    }
}