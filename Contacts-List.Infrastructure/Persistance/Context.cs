using Contacts_List.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Infrastructure.Persistance
{
    public class Context : IdentityDbContext
    {

        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tContact> Contacts { get; set; } = null!;

        public DbSet<tCategory> Category { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<tContact>()
                .HasIndex(p => new { p.Email })
                .IsUnique(true);
        }
    }
}
