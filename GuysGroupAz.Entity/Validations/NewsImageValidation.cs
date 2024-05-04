using FluentValidation;
using FluentValidation.Validators;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Validations
{
    public class NewsImageValidation : AbstractValidator<NewsImage>
    {
        public NewsImageValidation()
        {
            
        }
    }
}
