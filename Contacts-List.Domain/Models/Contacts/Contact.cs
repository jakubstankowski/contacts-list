namespace Contacts_List.Domain.Models.Contacts
{
    /// <summary>
    ///  Model kontaktu
    /// </summary>
    public class Contact
    {
        public int ContactId { get; set; }
        
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

    }
}
