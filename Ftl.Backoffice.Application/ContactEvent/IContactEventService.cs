using AutoMapper;
using Ftl.Backoffice.Application.ContactEvent.Dtos;
using Ftl.Backoffice.Core.Entities;
using Ftl.Backoffice.DataAccess.Persistance;

namespace Ftl.Backoffice.Application.ContactEvent
{
    public interface IContactEventService
    {
        public Task<IList<ContactEventItem>> GetAsync(int? contactId, CancellationToken cancellationToken = default);
        public Task<ContactEventItem?> GetOneAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<ContactEventItem> CreateAsync(CreateContactEventDto createContactDto, CancellationToken cancellationToken = default);
        public Task<ContactEventItem?> UpdateAsync(Guid id, UpdateContactEventDto updateContactDto, CancellationToken cancellationToken = default);
        public Task<ContactEventItem?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    }
}