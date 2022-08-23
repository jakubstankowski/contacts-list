using Contacts_List.Application.Interfaces;
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
    }
}
