using Contacts_List.Domain.Models.Contacts;

namespace Contacts_List.Application.Interfaces
{
    public interface IContactService
    {
        public Task<IEnumerable<Contact>> GetAllContactsAsync();

        public Task<ContactDetails> GetContactDetailsBydIdAsync(int id);

        public Task AddOrUpdateContactAsync(ContactCreate model);

        public Task DeleteContactByIdAsync(int id);
    }
}
