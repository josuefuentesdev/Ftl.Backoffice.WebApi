using AutoMapper;
using Ftl.Backoffice.Application.Order.Dtos;
using Ftl.Backoffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, OrderItem>();
            CreateMap<UpdateOrderDto, OrderItem>();
        }
    }
}
