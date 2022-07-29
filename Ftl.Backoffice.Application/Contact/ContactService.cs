using AutoMapper;
using Ftl.Backoffice.Application.Contact.Dtos;
using Ftl.Backoffice.Core.Entities;
using Ftl.Backoffice.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Ftl.Backoffice.Application.Contact
{
    public class ContactService : IContactService
    {
        private readonly FtlDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(FtlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ContactItem>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Contacts
                .ToListAsync();
        }
        
        public async Task<ContactItem?> GetOneAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Contacts
                .FindAsync(new object[] { id }, cancellationToken);
        }
        
        public async Task<ContactItem> CreateAsync(CreateContactDto createContactDto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<ContactItem>(createContactDto);
            
            _context.Contacts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            
            return entity;
        }

        public async Task<ContactItem?> UpdateAsync(int id, UpdateContactDto updateContactDto, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);
            
            if (entity is null) return null;

            entity = _mapper.Map(updateContactDto, entity);
            
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<ContactItem?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneAsync(id, cancellationToken);

            if (entity is null) return null;

            _context.Contacts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            
            return entity;
        }
    }
}
