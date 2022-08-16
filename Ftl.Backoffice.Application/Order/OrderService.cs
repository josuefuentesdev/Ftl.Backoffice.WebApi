using AutoMapper;
using Ftl.Backoffice.Application.Contact;
using Ftl.Backoffice.Application.Order.Dtos;
using Ftl.Backoffice.Core.Entities;
using Ftl.Backoffice.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order
{
    public class OrderService : IOrderService
    {
        private readonly FtlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public OrderService(FtlDbContext context, IMapper mapper, IContactService contactService)
        {
            _context = context;
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task<IList<OrderItem>> GetAsync(string? executionId, CancellationToken cancellationToken = default)
        {
            var orders = _context.Orders.AsQueryable();

            if (executionId != null) orders = orders.Where(x => x.ExecutionId == executionId);

            return await orders
                .ToListAsync();
        }

        public async Task<OrdersStatsDto> GetOrdersStatsAsync(FilterOrderDto? filters, CancellationToken cancellationToken = default)
        {
            var orders = _context.Orders.AsQueryable();

            if (filters != null && filters != new FilterOrderDto())
            {
                orders = orders.Where(x => x.Created >= filters.StartAt && x.Created <= filters.EndAt);
            }

            var stats = orders
                .GroupBy(o => 1)
                .Select(g => new OrdersStatsDto
                {
                    Count = g.Count(),
                    Revenue = g.Sum(x => x.NetPrice),
                    LastOrder = g.Max(x => x.Created)
                });

            var result = await stats.FirstOrDefaultAsync();


            return result;
        }

        public async Task<OrderItem?> GetOneAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
                .FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<OrderItem> CreateAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken = default)
        {
            var contact = await _contactService.GetOneAsync(createOrderDto.ContactId);
            if (contact == null) throw new Exception("Contact Doesn't exist");
            
            var entity = _mapper.Map<OrderItem>(createOrderDto);
            // set the latest contact data information
            entity.ContactEmail = contact.Email;

            _context.Orders.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<OrderItem?> UpdateAsync(int id, UpdateOrderDto updateOrderDto, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);

            if (entity is null) return null;

            entity = _mapper.Map(updateOrderDto, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<OrderItem?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);

            if (entity is null) return null;

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
