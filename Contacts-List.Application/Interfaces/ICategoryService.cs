using Contacts_List.Domain.Models.Category;

namespace Contacts_List.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategoryAsync();

    }
}
