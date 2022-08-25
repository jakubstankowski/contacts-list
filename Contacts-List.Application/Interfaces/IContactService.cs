using Contacts_List.Domain.Models.Contacts;

namespace Contacts_List.Application.Interfaces
{
    public interface IContactService
    {
        public Task<IEnumerable<Contact>> GetAllContactsAsync();

        public Task<ContactDetails> GetContactDetailsBydId(int id);

        public Task AddOrUpdateContact(ContactCreate model);

        public Task DeleteContactById(int id);
    }
}
