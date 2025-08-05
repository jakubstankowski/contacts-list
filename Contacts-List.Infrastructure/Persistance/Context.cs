using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Infrastructure.Persistance
{
    public class Context : IdentityDbContext, IContext
    {

        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<Category> Category { get; set; } = null!;

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync(new());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contact>()
                .HasIndex(p => new { p.Email })
                .IsUnique(true);
        }
    }
}
