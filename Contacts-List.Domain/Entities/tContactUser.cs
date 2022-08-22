using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_List.Domain.Entities
{
    /// <summary>
    /// Kontakt
    /// </summary>
    public class tContactUser : IdentityUser
    {
        /// <summary>
        /// Nazwa wyświetlana
        /// </summary>
        public string? DisplayName { get; set; }


    }
}
