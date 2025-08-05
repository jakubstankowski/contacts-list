using System.ComponentModel.DataAnnotations;

namespace Contacts_List.Domain.Entities
{
    /// <summary>
    ///  Kategorie kontatków
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id Kategorii kontaktów
        /// </summary>
        /// 
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nazwa kategorii kontaktów
        /// </summary>
        public string Name { get; set; } = null!;


        public bool IsDeleted { get; set; }
    }
}
