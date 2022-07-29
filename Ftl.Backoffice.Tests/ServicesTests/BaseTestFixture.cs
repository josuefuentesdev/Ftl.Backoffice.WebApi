using AutoMapper;
using Ftl.Backoffice.Application.Contact.Profiles;
using Ftl.Backoffice.DataAccess.Persistance;
using Ftl.Backoffice.Shared.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Ftl.Backoffice.Tests.ServicesTests
{
    public class BaseTestFixture : IDisposable
    {
        private readonly ICurrentUserService currentUserService;
        public readonly FtlDbContext context;
        public BaseTestFixture()
        {
            currentUserService = Substitute.For<ICurrentUserService>();
            currentUserService.UserId.Returns("userId");

            var options = new DbContextOptionsBuilder<FtlDbContext>()
                .UseInMemoryDatabase("FtlDbContext")
                .Options;

            
            context = new FtlDbContext(options, currentUserService);

            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactProfile>();
            });
            Mapper = config.CreateMapper();
        }

        public IMapper Mapper { get; }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
