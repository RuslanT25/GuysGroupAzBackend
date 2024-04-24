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
    public class SendMessageValidation : AbstractValidator<SendMessage>
    {
        public SendMessageValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(13);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(500);
        }
    }
}
