using AutoMapper;
using Ftl.Backoffice.Application.Contact.Dtos;
using Ftl.Backoffice.Application.Order.Dtos;
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

        public async Task<IList<GetContactsResponseDto>> GetAsync(FilterContactDto? filters, CancellationToken cancellationToken = default)
        {
            var contacts = _context.Contacts.AsQueryable();

            if (filters != null && filters != new FilterContactDto())
            {
                contacts = contacts.Where(x => x.Created >= filters.StartAt && x.Created <= filters.EndAt);
            }
            var contactList = await contacts.Select(contact => _mapper.Map<GetContactsResponseDto>(contact)).ToListAsync();

            return contactList;
        }
        
        public async Task<GetOneContactResponseDto?> GetOneAsync(int id, CancellationToken cancellationToken = default)
        {
            var contact = await _context.Contacts
                .FindAsync(new object[] { id }, cancellationToken);

            var contactDto = _mapper.Map<GetOneContactResponseDto>(contact);

            return contactDto;
        }

        private async Task<ContactItem?> GetOneEntityAsync(int id, CancellationToken cancellationToken = default)
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
            var entity = await GetOneEntityAsync(id, cancellationToken);
            
            if (entity is null) return null;

            entity = _mapper.Map(updateContactDto, entity);
            
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<ContactItem?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetOneEntityAsync(id, cancellationToken);

            if (entity is null) return null;

            _context.Contacts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            
            return entity;
        }
    }
}
