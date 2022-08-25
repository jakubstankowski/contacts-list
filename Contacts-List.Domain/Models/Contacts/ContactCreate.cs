namespace Contacts_List.Domain.Models.Contacts
{
    /// <summary>
    ///  Model utworzenia nowego kontaktu
    /// </summary>
    public class ContactCreate
    {
        /// <summary>
        /// Id Kontaktu
        /// </summary>
        public int? ContactId { get; set; }
        
        /// <summary>
        /// Imię
        /// </summary>
        public string? FirstName { get; set; }
        
        /// <summary>
        /// Nazwisko
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Numer kontaktowy
        /// </summary>
        public long? PhoneNumber { get; set; }

        /// <summary>
        /// Data urodzenia
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Kategoria Id
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Inna kategoria
        /// </summary>
        public string? OthersCategory { get; set; }
    }
}
