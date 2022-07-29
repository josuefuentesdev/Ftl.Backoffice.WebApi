namespace Ftl.Backoffice.Data.Entities
{
    public class ContactEvent
    {
        public Guid Id { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string? EventType { get; set; }
        public bool? IsJson { get; set; }
        public byte[]? Data { get; set; }
        public byte[]? MetaData { get; set; }
    }
}
