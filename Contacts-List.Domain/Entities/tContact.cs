﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts_List.Domain.Entities
{
    /// <summary>
    ///  Kontakt
    /// </summary>
    public class tContact
    {
        /// <summary>
        /// Id Kontaktu
        /// </summary>
        [Key]
        public int ContactId { get; set; }

        /// <summary>
        /// Imię
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Nazwisko
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Numer kontaktowy
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Data urodzenia
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Kategoria
        /// </summary>
        public tCategory? Category { get; set; } = null!;

        /// <summary>
        /// Kategoria Id
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Inna kategoria
        /// </summary>
        public string? OthersCategory { get; set; }


        public bool IsDeleted { get; set; }

    }
}
