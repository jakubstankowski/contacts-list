using Contacts_List.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Infrastructure.Persistance
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tCategory> Category { get; set; } = null!;
    }
}
