using FluentValidation;
using Ftl.Backoffice.Application.Contact.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Contact.Validators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
