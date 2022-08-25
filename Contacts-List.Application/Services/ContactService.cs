using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Models.Contacts;
using Microsoft.EntityFrameworkCore;

namespace Contacts_List.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContext _context;

        public ContactService(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await (from con in _context.Contacts
                          select new Contact
                          {
                              ContactId = con.ContactId,
                              DisplayName = $"{con.FirstName} {con.LastName}",
                              Category =  con.Category.Name,
                              DateOfBirth = con.DateOfBirth,
                          }).ToListAsync();
        }
    }
}
