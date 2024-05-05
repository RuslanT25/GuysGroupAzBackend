using FluentValidation;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            
        }
    }
}