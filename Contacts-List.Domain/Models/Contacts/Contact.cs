namespace Contacts_List.Domain.Models.Contacts
{
    /// <summary>
    ///  Model kontaktu
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///  Model Kontakt Id
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        ///  Model nazwa wyświetlana kontaktu
        /// </summary>
        public string DisplayName { get; set; } = null!;

        /// <summary>
        ///  Model kategoria kontaktu
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        ///  Model data urodzenia kontaktu
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
    }
}
