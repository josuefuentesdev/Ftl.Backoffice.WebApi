using Ftl.Backoffice.Application.Order.Dtos;
using Ftl.Backoffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order
{
    public interface IOrderService
    {
        public Task<IList<OrderItem>> GetAsync(string? executionId, CancellationToken cancellationToken = default);
        public Task<OrderItem?> GetOneAsync(int id, CancellationToken cancellationToken = default);
        public Task<OrderItem> CreateAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken = default);
        public Task<OrderItem?> UpdateAsync(int id, UpdateOrderDto createOrderDto, CancellationToken cancellationToken = default);
        public Task<OrderItem?> DeleteAsync(int id, CancellationToken cancellationToken = default);
        public Task<OrdersStatsDto> GetOrdersStatsAsync(FilterOrderDto? filters, CancellationToken cancellationToken = default);
    }
}
