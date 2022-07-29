namespace Ftl.Backoffice.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<ContactEvent> ContactEvents { get; set; }
    }
}
