using Ftl.Backoffice.Core.Common;

namespace Ftl.Backoffice.Core.Entities
{
    public class ContactItem : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public ICollection<ContactEventItem>? ContactEvents { get; set; }
    }
}
