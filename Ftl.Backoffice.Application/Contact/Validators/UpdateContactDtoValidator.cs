using FluentValidation;
using Ftl.Backoffice.Application.Contact.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Contact.Validators
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
