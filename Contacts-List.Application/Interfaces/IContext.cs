using Contacts_List.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Category { get; set; }

        Task<int> SaveChangesAsync();
    }
}
