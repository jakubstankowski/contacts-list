using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Entities;
using Contacts_List.Domain.Models.Contacts;
using Microsoft.EntityFrameworkCore;
using Contact = Contacts_List.Domain.Entities.Contact;

namespace Contacts_List.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContext _context;

        public ContactService(IContext context)
        {
            _context = context;
        }

        public async Task AddOrUpdateContactAsync(ContactCreate model)
        {
            var dbContact = new Contact();

            if (model.ContactId.HasValue && model.ContactId > 0)
            {
                dbContact = await _context.Contacts.SingleAsync(c => c.ContactId == model.ContactId);
            }

            dbContact.FirstName = model.FirstName;
            dbContact.LastName = model.LastName;
            dbContact.PhoneNumber = model.PhoneNumber;
            dbContact.Email = model.Email;
            dbContact.DateOfBirth = model.DateOfBirth;
            dbContact.CategoryId = model.CategoryId;

            if (!model.CategoryId.HasValue || model.ContactId == 0)
            {
                _context.Contacts.Add(dbContact);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactByIdAsync(int contactId)
        {
            var contact = await _context.Contacts.Where(x => x.ContactId == contactId).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new ArgumentNullException();
            }

            contact.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Models.Contacts.Contact>> GetAllContactsAsync()
        {
            return await (from con in _context.Contacts
                          where con.IsDeleted == false
                          select new Domain.Models.Contacts.Contact
                          {
                              ContactId = con.ContactId,
                              FirstName = con.FirstName,
                              LastName = con.LastName
                          }).ToListAsync();
        }

        public async Task<ContactDetails> GetContactDetailsBydIdAsync(int id)
        {
            var result = await (from con in _context.Contacts
                                where con.ContactId == id && con.IsDeleted == false
                                select new ContactDetails
                                {
                                    ContactId = con.ContactId,
                                    FirstName =  con.FirstName,
                                    LastName =  con.LastName,
                                    Category = con.Category != null ? con.Category.Name : string.Empty,
                                    DateOfBirth = con.DateOfBirth,
                                    PhoneNumber = con.PhoneNumber,
                                    Email = con.Email
                                }).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return result;
            }
        }
    }
}
