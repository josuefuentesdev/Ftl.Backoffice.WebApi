using Ftl.Backoffice.Core.Common;

namespace Ftl.Backoffice.Core.Entities
{
    public class ContactEventItem : AuditableEntity
    {
        public Guid Id { get; set; }
        public ContactItem Contact { get; set; }
        public int ContactId { get; set; }
        public string EventType { get; set; }
        public bool? IsJson { get; set; }
        public byte[]? Data { get; set; }
        public byte[]? MetaData { get; set; }
    }
}
