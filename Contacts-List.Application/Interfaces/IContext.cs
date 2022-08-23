using Contacts_List.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Application.Interfaces
{
    public interface IContext
    {
        public DbSet<tContact> Contacts { get; set; }

        public DbSet<tCategory> Category { get; set; }
    }
}
