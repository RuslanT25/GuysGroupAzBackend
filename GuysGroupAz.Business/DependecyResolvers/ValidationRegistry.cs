using GuysGroupAz.Entity.Validations;
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

            return services;
        }
    }
}
