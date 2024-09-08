
using CarBook.Application.Features.Contacts.Commands;
using CarBook.Application.Features.Contacts.Handlers.Read;
using CarBook.Application.Features.Contacts.Handlers.Write;
using CarBook.Application.Features.Contacts.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(GetContactByIdQueryHandler getContactByIdQueryHandler,
            GetContactQueryHandler getContactQueryHandler,
            CreateContactCommandHandler createContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler, 
            RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact basariyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact basariyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command, int id)
        {
            await _updateContactCommandHandler.Handle(command, id);
            return Ok("Contact basariyla güncellendi");
        }
    }
}
