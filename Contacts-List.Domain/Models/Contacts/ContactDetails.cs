namespace Contacts_List.Domain.Models.Contacts
{
    /// <summary>
    ///  Model szczegółowy kontaktu
    /// </summary>
    public class ContactDetails : Contact
    {
        public string? Category { get; set; }

        public int? CategoryId { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public string? PhoneNumber { get; set; }
        
        public string? Email { get; set; }
    }
}
