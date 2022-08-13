using AutoMapper;
using Ftl.Backoffice.Application.ContactEvent.Dtos;
using Ftl.Backoffice.Core.Entities;
using Ftl.Backoffice.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.ContactEvent
{
    public class ContactEventService : IContactEventService
    {
        private readonly FtlDbContext _context;
        private readonly IMapper _mapper;

        public ContactEventService(FtlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ContactEventItem>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ContactEvents
                .ToListAsync();
        }

        public async Task<ContactEventItem?> GetOneAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ContactEvents
                .FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<ContactEventItem> CreateAsync(CreateContactEventDto createContactDto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<ContactEventItem>(createContactDto);

            _context.ContactEvents.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<ContactEventItem?> UpdateAsync(Guid id, UpdateContactEventDto updateContactDto, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);

            if (entity is null) return null;

            entity = _mapper.Map(updateContactDto, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<ContactEventItem?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);

            if (entity is null) return null;

            _context.ContactEvents.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
