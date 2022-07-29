using Ftl.Backoffice.Application.Contact;
using Ftl.Backoffice.Application.Contact.Dtos;

namespace Ftl.Backoffice.Tests.ServicesTests
{
    public class ContactServiceTest : BaseTestFixture
    {
        // sut
        private readonly IContactService _contactService;
        public ContactServiceTest()
        {
            _contactService = new ContactService(context, Mapper);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnContactItem()
        {
            var contactDto = new CreateContactDto()
            {
                Email = "test@gmail.com",
                Name = "Test"
            };

            var result = await _contactService.CreateAsync(contactDto);
            Assert.NotNull(result);
        }


        [Fact]
        public async Task GetAsync_ShouldReturnListOfContactItems()
        {
            var result = await _contactService.GetAsync();
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetOneAsync_ShouldReturnContactItem()
        {
            var result = await _contactService.GetOneAsync(1);
            Assert.NotNull(result);
        }


        [Fact]
        public async Task UpdateAsync_ShouldReturnContactItem()
        {
            var result = await _contactService.UpdateAsync(1, new UpdateContactDto());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnContactItem()
        {
            var result = await _contactService.DeleteAsync(1);
            Assert.NotNull(result);
        }
    }
}
