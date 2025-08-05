using Contacts_List.Application.Interfaces;
using Contacts_List.Domain.Models.Contacts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts_List.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _contactService.GetAllContactsAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetContactDetailsById/{contactId}")]
        public async Task<IActionResult> GetContactDetailsById(int? contactId)
        {
            if (!contactId.HasValue)
            {
                return BadRequest("Brak id kontaktu");
            }

            var result = await _contactService.GetContactDetailsBydIdAsync(contactId.Value);

            return Ok(result);
        }
        
        [HttpPost]
        [Route("AddOrUpdateContact")]
        public async Task<IActionResult> AddOrUpdateContact(ContactCreate model)
        {
            try
            {
                await _contactService.AddOrUpdateContactAsync(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }


            return Ok();
        }

        [HttpPost]
        [Route("DeleteContactById/{contactId}")]
        public async Task<IActionResult> DeleteContactById(int contactId)
        {
            try
            {
                await _contactService.DeleteContactByIdAsync(contactId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }


            return Ok();
        }
    }
}
