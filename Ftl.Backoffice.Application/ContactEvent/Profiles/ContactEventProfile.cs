using AutoMapper;
using Ftl.Backoffice.Application.ContactEvent.Dtos;
using Ftl.Backoffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.ContactEvent.Profiles
{
    public class ContactEventProfile : Profile
    {
        public ContactEventProfile()
        {
            CreateMap<CreateContactEventDto, ContactEventItem>();
            CreateMap<UpdateContactEventDto, ContactEventItem>();
        }
    }
}
