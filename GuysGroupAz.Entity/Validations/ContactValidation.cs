using FluentValidation;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^\+994(50|51|55|60|70|77|99)\d{8}$")
                    .WithMessage("The phone number must start with '+994' and the next two digits must be one of 50, 51, 55, 60, 70, 77, 99. Afterwards, 8 numbers must be entered.");

            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
