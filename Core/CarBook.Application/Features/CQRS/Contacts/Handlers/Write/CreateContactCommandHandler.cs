using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Contacts.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Contacts.Handlers.Write
{
    public class CreateContactCommandHandler : BaseHandler<Contact>
    {
        public CreateContactCommandHandler(IRepository<Contact> repository) : base(repository)
        {
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            {
                Email = command.Email,
                Message = command.Message,
                Name = command.Name,
                SendDate = DateTime.Now,
                Subject = command.Subject
            });
        }
    }
}
