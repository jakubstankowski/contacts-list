using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IContext _context;

        public CategoryService(IContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await (from con in _context.Category
                          where con.IsDeleted == false
                          select new Category
                          {
                              CategoryId = con.CategoryId,
                              Name = con.Name
                          }).ToListAsync();
        }
    }
}
