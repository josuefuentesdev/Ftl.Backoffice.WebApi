using Ftl.Backoffice.Core.Common;
using Ftl.Backoffice.Core.Entities;
using Ftl.Backoffice.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Ftl.Backoffice.DataAccess.Persistance
{
    public class FtlDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public FtlDbContext(DbContextOptions<FtlDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<ContactItem> Contacts { get; set; }
        public DbSet<ContactEventItem> ContactEvents { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
