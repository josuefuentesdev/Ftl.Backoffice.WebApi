using AutoMapper;
using Ftl.Backoffice.Application.Contact.Dtos;
using Ftl.Backoffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Contact.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactDto, ContactItem>();
            CreateMap<UpdateContactDto, ContactItem>();
            CreateMap<ContactItem, GetContactsResponseDto>();
            CreateMap<ContactItem, GetOneContactResponseDto>();
        }
    }
}
