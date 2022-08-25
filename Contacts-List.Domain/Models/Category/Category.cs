namespace Contacts_List.Domain.Models.Category
{
    /// <summary>
    ///  Model kategorii
    /// </summary>
    public class Category
    {
        /// <summary>
        ///  Kategoria ID
        /// </summary>
        public int CategoryId { get; set; } 
       
        /// <summary>
        ///  Nazwa kategorii
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
