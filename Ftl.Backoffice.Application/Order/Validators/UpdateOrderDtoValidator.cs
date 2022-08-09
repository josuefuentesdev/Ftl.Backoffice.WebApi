using FluentValidation;
using Ftl.Backoffice.Application.Order.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order.Validators
{
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
        }
    }
}
