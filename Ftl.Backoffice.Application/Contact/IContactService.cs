using Ftl.Backoffice.Application.Contact.Dtos;
using Ftl.Backoffice.Core.Entities;

namespace Ftl.Backoffice.Application.Contact
{
    public interface IContactService
    {
        public Task<IList<GetContactsResponseDto>> GetAsync(FilterContactDto? filters, CancellationToken cancellationToken = default);
        public Task<GetOneContactResponseDto?> GetOneAsync(int id, bool obfuscate = true, CancellationToken cancellationToken = default);
        public Task<ContactItem> CreateAsync(CreateContactDto createContactDto, CancellationToken cancellationToken = default);
        public Task<ContactItem?> UpdateAsync(int id, UpdateContactDto createContactDto, CancellationToken cancellationToken = default);
        public Task<ContactItem?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
