namespace Contacts_List.Domain.Models.Contacts
{
    /// <summary>
    ///  Model szczegółowy kontaktu
    /// </summary>
    public class ContactDetails : Contact
    {
        /// <summary>
        ///  Model kategoria kontaktu
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        ///  Model data urodzenia kontaktu
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        ///  Model numer telefonu
        /// </summary>
        public long? PhoneNumber { get; set; }

        /// <summary>
        ///  Model email
        /// </summary>
        public string? Email { get; set; }
    }
}
